import { View, Text, StyleSheet } from "react-native";
import React from "react";

import Icon from "react-native-vector-icons/FontAwesome5";

export default function DoorCard(props) {
	const text = {
		color: props.door.isOpen ? "#25ff76" : "#ff4843",
		lineHeight: 16,
		fontSize: 19,
		fontWeight: "bold",
	};

	return (
		<View style={styles.card}>
			<View style={styles.spacing}>
				<View style={styles.bgStyles}>
					<View style={styles.icon}>
						{props.door.isOpen ? (
							<Icon name="door-open" color={"white"} size={25} />
						) : (
							<Icon name="door-closed" color={"white"} size={25} />
						)}
					</View>
					<View style={styles.name}>
						<Text style={styles.text}>{props.door.roomName}</Text>
					</View>
					<View style={styles.state}>
						<Text style={text}>{props.door.isOpen ? "OPEN" : "CLOSED"}</Text>
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
		backgroundColor: "#232e42",
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
		color: "white",
		lineHeight: 16,
		fontSize: 19,
		fontWeight: "bold",
	},
});
