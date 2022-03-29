import {
	Modal,
	View,
	Text,
	Pressable,
	StyleSheet,
	ScrollView,
	ActivityIndicator,
} from "react-native";
import React, { useEffect } from "react";
import Icon from "react-native-vector-icons/FontAwesome";
import { actionCreator } from "../store/action-creators/photo-action-creators";
import { connect } from "react-redux";

import PhotosList from "../components/photos/PhotosList";

function Photo(props) {
	useEffect(() => {
		if (!props.isTakingPicture) props.getPhotos();
	}, [props.isTakingPicture]);

	useEffect(() => {
		if (props.video !== null) setUrl(props.video.url);
	}, [props.video]);

	function onClick() {
		props.addPhoto();
	}

	return (
		<View style={styles.content}>
			<Modal
				animationType="slide"
				transparent={false}
				visible={props.isTakingPicture}
			>
				<View style={styles.take_photo}>
					<ActivityIndicator
						size="large"
						color="#35bbb4"
						style={styles.spinner}
					/>
					<Text style={styles.text_button}>Taking Picture...</Text>
				</View>
			</Modal>
			<View style={styles.content}>
				<Text style={styles.gallery}>Gallery</Text>
				<ScrollView style={styles.gallery_container}>
					<PhotosList dataList={props.photo} />
				</ScrollView>
				<View style={styles.button_container}>
					<Pressable style={styles.button} onPress={onClick}>
						<Icon name="camera" color="#ffff" size={25} />
						<Text style={styles.text_button}>Take a Picture</Text>
					</Pressable>
				</View>
			</View>
		</View>
	);
}

const styles = StyleSheet.create({
	content: {
		height: "100%",
		paddingVertical: "10%",
		paddingTop: 50,
		backgroundColor: "#35435e",
	},
	gallery_container: {
		height: "83%",
	},
	gallery: {
		textAlign: "center",
		marginBottom: 30,
		fontSize: 28,
		fontWeight: "bold",
		color: "white",
	},
	button_container: {
		alignItems: "center",
		height: 50,
		marginTop: 30,
		marginBottom: 30,
	},
	button: {
		flex: 1,
		flexDirection: "row",
		alignItems: "center",
		justifyContent: "space-around",
		width: "70%",
		paddingHorizontal: 20,
		borderRadius: 8,
		backgroundColor: "#35bbb4",
	},
	text_button: {
		textAlign: "center",
		fontSize: 18,
		fontWeight: "bold",
		letterSpacing: 0.55,
		color: "white",
	},
	take_photo: {
		flex: 1,
		height: "100%",
		width: "100%",
		justifyContent: "center",
		alignItems: "center",
		backgroundColor: "#35435e",
	},
	spinner: {
		marginTop: 20,
		marginBottom: 40,
	},
});

export default connect((state) => ({ ...state.photo }), { ...actionCreator })(
	Photo
);
