import React, { useEffect } from "react";
import { View, Text } from "react-native";
import { actionCreator as doorActionCreators } from "../store/action-creators/door-action-creators";
import { actionCreator as lightActionCreators } from "../store/action-creators/light-action-creators";
import { connect } from "react-redux";

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
		<View style={{ flex: 1, alignItems: "center", justifyContent: "center" }}>
			<Text>Home Screen</Text>
		</View>
	);
};

export default connect((state) => ({ door: state.door, light: state.light }), {
	doorConnect: doorActionCreators.connect,
	lightConnect: lightActionCreators.connect,
	getDoorStream: doorActionCreators.getStream,
	getLightStream: lightActionCreators.getStream,
})(Home);
