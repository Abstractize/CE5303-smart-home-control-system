import React, { useEffect } from "react";
import { View, Text, StyleSheet, Image } from "react-native";
import { actionCreator as doorActionCreators } from "../store/action-creators/door-action-creators";
import { actionCreator as lightActionCreators } from "../store/action-creators/light-action-creators";
import { connect } from "react-redux";
import { RootTagContext } from "react-native/Libraries/ReactNative/RootTag";

const Home = (props) => {
	useEffect(() => {
		if (!props.door.connection) props.doorConnect();
		if (!props.light.connection) props.lightConnect();
	}, []);

	useEffect(() => {
		if (props.door.connection) props.getDoorStream();
	}, [props.door.connection]);

	useEffect(() => {
		if (props.door.connection) props.getLightStream();
	}, [props.light.connection]);

	useEffect(() => {
		//console.log(props.door.data);
	}, [props.door.data, props.light.data]);

	return (
		<View style={styles.content}>
			<View style={styles.home_container}>
				<Text style={styles.home}>Home State</Text>
				<Image
					style={styles.image}
					source={require("../assets/house_map.png")}
				/>
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
	home_container: {
		height: "90%",
	},
	home: {
		textAlign: "center",
		marginTop: 20,
		marginBottom: 130,
		fontSize: 28,
		fontWeight: "bold",
		color: "white",
	},
	image: {
		width: "100%",
		height: "58%",
		borderRadius: 15,
		transform: [{ rotate: "90deg" }],
	},
});

export default connect((state) => ({ door: state.door, light: state.light }), {
	doorConnect: doorActionCreators.connect,
	lightConnect: lightActionCreators.connect,
	getDoorStream: doorActionCreators.getStream,
	getLightStream: lightActionCreators.getStream,
})(Home);
