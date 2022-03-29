import React, { useEffect } from "react";
import { connect } from "react-redux";
import { View, Text, StyleSheet } from "react-native";
import { actionCreator as lightActionCreators } from "../store/action-creators/light-action-creators";

import LightsList from "../components/lights/LightsList";

const Light = (props) => {

	useEffect(() => {
		if(!props.connection)
			props.connect();
		
	}, []);

	useEffect(() => {
		props.getStream();
	}, [props.connection]);

	useEffect(() => {
		if (props.error) console.error(props.error);
	}, [props.error]);

	return (
		<View style={styles.content}>
			<View style={styles.light_container}>
				<Text style={styles.light}>Lights State</Text>
				<LightsList dataList={props.data} onChange={props.switchLight} />
			</View>
		</View>
	);
};

const styles = StyleSheet.create({
	content: {
		height: "100%",
		paddingVertical: "10%",
		paddingTop: 70,
		backgroundColor: "#35435e",
	},
	light_container: {
		height: "90%",
	},
	light: {
		textAlign: "center",
		marginTop: 20,
		marginBottom: 10,
		fontSize: 28,
		fontWeight: "bold",
		color: "white",
	},
});

export default connect((state) => ({ ...state.light }), {
	...lightActionCreators,
})(Light);
