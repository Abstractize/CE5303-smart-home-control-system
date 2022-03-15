import { View, Text, StyleSheet, Switch } from "react-native";
import React from "react";

import Icon from "react-native-vector-icons/Fontisto";

export default function LightCard(props) {
	return (
		<View style={styles.card}>
			<View style={styles.spacing}>
				<View style={styles.bgStyles}>
					<View style={styles.icon}>
						<Icon
							name="day-sunny"
							color={props.light.isOn ? "yellow" : "#232e42"}
							size={35}
						/>
					</View>
					<View style={styles.name}>
						<Text style={styles.text}>{props.light.roomName}</Text>
					</View>
					<View style={styles.state}>
						<Switch
							trackColor={{ false: "#232e42", true: "#232e42" }}
							thumbColor={props.light.isOn ? "#fff" : "#fff"}
							ios_backgroundColor="#232e42"
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
		backgroundColor: "#35bbb4",
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
		flex: 1,
		justifyContent: "center",
		alignItems: "center",
		width: "25%",
	},
	textContainer: {
		width: "33.33%",
	},
	text: {
		lineHeight: 16,
		fontSize: 19,
		fontWeight: "bold",
		color: "white",
	},
});
