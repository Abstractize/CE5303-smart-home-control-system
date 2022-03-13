import React, { useEffect } from "react";
import { connect } from "react-redux";
import { View, Text, StyleSheet } from "react-native";
import { actionCreator as doorActionCreators } from "../store/action-creators/door-action-creators";

import DoorsList from "../components/doors/DoorsList";

const Door = (props) => {
	useEffect(() => {
		props.connect();

		return () => {
			props.disconnect();
		};
	}, []);

	useEffect(() => {
		props.getStream();
	}, [props.connection]);

	useEffect(() => {
		if (props.data !== []) console.log(props.data);
	}, [props.data]);

	useEffect(() => {
		if (props.error) console.error(props.error);
	}, [props.error]);

	return (
		<View style={styles.content}>
			<View style={styles.doors_container}>
				<Text style={styles.door}>Doors State</Text>
				<DoorsList dataList={props.data} />
			</View>
		</View>
	);
};

const styles = StyleSheet.create({
	content: {
		height: "100%",
		paddingVertical: "10%",
		marginTop: 50,
	},
	doors_container: {
		height: "83%",
	},
	door: {
		textAlign: "center",
		marginTop: 10,
		marginBottom: 30,
		fontSize: 28,
		fontWeight: "bold",
	},
});

export default connect((state) => ({ ...state.door }), {
	...doorActionCreators,
})(Door);
