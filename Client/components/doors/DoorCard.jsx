import { View, Text, StyleSheet } from "react-native";
import React from "react";

import Icon from "react-native-vector-icons/FontAwesome5";
import { capitalize } from "lodash";

export default function DoorCard(props) {
	const bgStyles = {
		backgroundColor: props.door.isOpen ? "#890" : "#45f",
		height: "100%",
		borderRadius: 15,
	};

	return (
		<View style={styles.card}>
			<View style={styles.spacing}>
				<View style={bgStyles}>
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
							<Text style={styles.text}>
								{capitalize(props.door.isOpen.toString())}
							</Text>
						</View>
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
