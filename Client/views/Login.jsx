import React, { useState, useEffect } from "react";
import { connect } from "react-redux";
import {
	View,
	Text,
	TextInput,
	StyleSheet,
	Pressable,
	Image,
	ActivityIndicator,
} from "react-native";
import { useFormik } from "formik";
import * as Yup from "yup";
import { actionCreator as authActionCreators } from "../store/action-creators/auth-action-creators";
import Icon from "react-native-vector-icons/FontAwesome";

const Login = (props) => {
	const [error, setError] = useState("");

	const formik = useFormik({
		initialValues: initialValues(),
		validationSchema: Yup.object(validationSchema()),
		validateOnChange: false,
		onSubmit: (formValue) => {
			setError("");
			const { email, password } = formValue;

			props.login({ email: email, password: password });
		},
	});

	useEffect(() => {
		if (props.user) {
			props.navigation.navigate("Main");
		}
	}, [props.user]);

	useEffect(() => {
		setError(props.error?.response?.data);
	}, [props.error]);

	return (
		<View style={styles.content}>
			<Image
				source={require("../assets/home-icon.png")}
				style={{ width: 115, height: 115 }}
			/>
			<Text style={styles.title}>Smart Home</Text>
			<View style={styles.input_container}>
				<Icon name="envelope-o" color="#ffff" size={20} />
				<TextInput
					placeholder="Email"
					style={styles.input}
					autoCapitalize="none"
					autoComplete="email"
					placeholderTextColor="#ffff"
					value={formik.values.email}
					onChangeText={(text) => formik.setFieldValue("email", text)}
				></TextInput>
			</View>
			<View style={styles.input_container}>
				<Icon name="lock" color="#ffff" size={25} />
				<TextInput
					placeholder="Password"
					style={styles.input}
					autoCapitalize="none"
					autoComplete="password"
					secureTextEntry={true}
					placeholderTextColor="#ffff"
					value={formik.values.password}
					onChangeText={(text) => formik.setFieldValue("password", text)}
				></TextInput>
			</View>
			<View style={styles.button_container}>
				{props.isLoading ? (
					<View style={styles.spinner_container}>
						<ActivityIndicator
							size="large"
							color="#35bbb4"
							style={styles.spinner}
						/>
					</View>
				) : (
					<Pressable style={styles.button} onPress={formik.handleSubmit}>
						<Text style={styles.text_button}>LOG IN</Text>
					</Pressable>
				)}
			</View>
			<Text style={styles.error}>{formik.errors.email}</Text>
			<Text style={styles.error}>{formik.errors.password}</Text>
			<Text style={styles.error}>{error}</Text>
		</View>
	);
};

const styles = StyleSheet.create({
	content: {
		flex: 1,
		justifyContent: "center",
		alignItems: "center",
		height: "100%",
		paddingVertical: "10%",
		paddingHorizontal: "10%",
		backgroundColor: "#35435e",
	},
	title: {
		textAlign: "center",
		fontSize: 24,
		fontWeight: "bold",
		marginTop: 10,
		marginBottom: 65,
		color: "#fff",
	},
	input_container: {
		marginBottom: 40,
		flexDirection: "row",
		justifyContent: "center",
		alignItems: "center",
		height: 20,
	},
	input: {
		height: 40,
		margin: 12,
		borderWidth: 0,
		borderBottomWidth: 1,
		borderColor: "#fff",
		padding: 10,
		width: "90%",
		color: "#ffff",
		fontSize: 18,
	},
	button_container: {
		width: "95%",
		marginTop: 30,
		marginBottom: 40,
	},
	button: {
		paddingVertical: 12,
		paddingHorizontal: 20,
		borderRadius: 8,
		backgroundColor: "#35bbb4",
	},
	text_button: {
		textAlign: "center",
		fontSize: 16,
		lineHeight: 21,
		fontWeight: "bold",
		letterSpacing: 0.55,
		color: "white",
	},
	error: {
		textAlign: "center",
		fontSize: 18,
		color: "#fff",
		marginTop: 5,
	},
	spinner_container: {
		width: "100%",
		flex: 1,
		justifyContent: "center",
		alignItems: "center",
	},
	spinner: {
		marginTop: 20,
		marginBottom: 40,
	},
});

function initialValues() {
	return {
		email: "",
		password: "",
	};
}

function validationSchema() {
	return {
		email: Yup.string().required("You need a Email"),
		password: Yup.string().required("You need a Password"),
	};
}

export default connect((state) => ({ ...state.auth }), {
	...authActionCreators,
})(Login);
