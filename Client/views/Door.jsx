import React, { useEffect } from "react";
import { connect } from "react-redux";
import { View, Text, StyleSheet, ScrollView } from "react-native";
import { actionCreator as doorActionCreators } from "../store/action-creators/door-action-creators";

import DoorsList from "../components/doors/DoorsList";

const Door = (props) => {
	useEffect(() => {
		if (!props.connection) props.connect();
	}, []);

	useEffect(() => {
		props.getStream();
	}, [props.connection]);

	useEffect(() => {
		if (props.error) console.error(props.error);
	}, [props.error]);

	return (
		<View style={styles.content}>
			<ScrollView style={styles.doors_container}>
				<Text style={styles.door}>Doors State</Text>
				<DoorsList dataList={props.data} />
			</ScrollView>
		</View>
	);
};

const styles = StyleSheet.create({
	content: {
		height: "100%",
		paddingVertical: "10%",
		paddingTop: 80,
		backgroundColor: "#35435e",
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
		color: "white",
	},
});

export default connect((state) => ({ ...state.door }), {
	...doorActionCreators,
})(Door);
