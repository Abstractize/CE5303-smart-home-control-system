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

	const lightStyle = (id) => ({
		backgroundColor: props.light.data[id]?.isOn ? "yellow" : "",
	});

	const doorStyle = (id) => ({
		backgroundColor: props.door.data[id]?.isOpen ? "" : "red",
	});

	return (
		<View style={styles.content}>
			<View style={styles.home_container}>
				<Text style={styles.home}>Home State</Text>
				<View style={styles.imageContainer}>
					<View style={[styles.door1, doorStyle(0)]}></View>
					<View style={[styles.door2, doorStyle(1)]}></View>
					<View style={[styles.door3, doorStyle(2)]}></View>
					<View style={[styles.door4, doorStyle(3)]}></View>
					<View style={[styles.circle1, lightStyle(0)]}></View>
					<View style={[styles.circle2, lightStyle(1)]}></View>
					<View style={[styles.circle3, lightStyle(2)]}></View>
					<View style={[styles.circle4, lightStyle(3)]}></View>
					<View style={[styles.circle5, lightStyle(4)]}></View>
					<Image
						style={styles.image}
						source={require("../assets/house_map.png")}
					/>
				</View>
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
		marginBottom: 15,
		fontSize: 28,
		fontWeight: "bold",
		color: "white",
	},
	image: {
		width: "100%",
		height: "100%",
		borderRadius: 15,
		transform: [{ rotate: "90deg" }, { scale: 1.25 }],
		resizeMode: "contain",
	},
	imageContainer: {
		width: "100%",
		height: "90%",
		position: "relative",
	},
	door1: {
		width: 6,
		height: 82,
		top: 210,
		left: 169,
		zIndex: 1,
		position: "absolute",
	},
	door2: {
		width: 78,
		height: 6,
		top: 571,
		left: 140,
		zIndex: 1,
		position: "absolute",
	},
	door3: {
		width: 6,
		height: 42,
		top: 265,
		left: 216,
		zIndex: 1,
		position: "absolute",
	},
	door4: {
		width: 6,
		height: 42,
		top: 123,
		left: 216,
		zIndex: 1,
		position: "absolute",
	},
	circle1: {
		width: 30,
		height: 30,
		top: 199,
		left: 79,
		opacity: 0.6,
		zIndex: 1,
		borderRadius: "100%",
		position: "absolute",
	},
	circle2: {
		width: 30,
		height: 30,
		top: 467,
		left: 73,
		opacity: 0.6,
		zIndex: 1,
		borderRadius: "100%",
		position: "absolute",
	},
	circle3: {
		width: 30,
		height: 30,
		top: 301,
		left: 282,
		opacity: 0.6,
		zIndex: 1,
		borderRadius: "100%",
		position: "absolute",
	},
	circle4: {
		width: 30,
		height: 30,
		top: 123,
		left: 291,
		opacity: 0.6,
		zIndex: 1,
		borderRadius: "100%",
		position: "absolute",
	},
	circle5: {
		width: 30,
		height: 30,
		top: 331,
		left: 76,
		opacity: 0.6,
		zIndex: 1,
		borderRadius: "100%",
		position: "absolute",
	},
});

export default connect((state) => ({ door: state.door, light: state.light }), {
	doorConnect: doorActionCreators.connect,
	lightConnect: lightActionCreators.connect,
	getDoorStream: doorActionCreators.getStream,
	getLightStream: lightActionCreators.getStream,
})(Home);
