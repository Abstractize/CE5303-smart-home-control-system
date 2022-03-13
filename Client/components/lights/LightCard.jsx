import { View, Text, StyleSheet, Switch } from "react-native";
import React from "react";

import Icon from "react-native-vector-icons/FontAwesome5";

export default function LightCard(props) {
	return (
		<View style={styles.card}>
			<View style={styles.spacing}>
				<View style={styles.bgStyles}>
					<View style={styles.icon}>
						<Icon
							name="lightbulb"
							color={props.light.isOn ? "yellow" : "white"}
							size={25}
						/>
					</View>
					<View style={styles.name}>
						<Text style={styles.text}>{props.light.roomName}</Text>
					</View>
					<View style={styles.state}>
						<Switch
							trackColor={{ false: "#767577", true: "#81b0ff" }}
							thumbColor={props.light.isOn ? "#f5dd4b" : "#f4f3f4"}
							ios_backgroundColor="#3e3e3e"
							onValueChange={() =>
								props.changeSwitch(props.light.id, {
									...props.light,
									isOn: !props.light.isOn,
								})
							}
							value={props.light.isOn}
						/>
					</View>
				</View>
			</View>
		</View>
	);
}

const styles = StyleSheet.create({
	card: {
		height: 120,
		width: "100%",
	},
	spacing: {
		flex: 1,
		padding: 5,
	},
	bgStyles: {
		flex: 1,
		flexDirection: "row",
		alignItems: "center",
		borderRadius: 15,
		height: "100%",
		backgroundColor: "black",
	},
	icon: {
		textAlign: "center",
		width: "25%",
	},
	name: {
		textAlign: "center",
		width: "50%",
	},
	state: {
		textAlign: "center",
		width: "25%",
	},
	textContainer: {
		width: "33.33%",
	},
	text: {
		lineHeight: 16,
		fontSize: 16,
		fontWeight: "bold",
		color: "white",
	},
});
