import { View, Text, ActivityIndicator, StyleSheet } from "react-native";
import React, { useEffect, useState } from "react";
import { API_URL } from '../constants';

export default function Loading(props) {
	const [error, setError] = useState(false);

	useEffect(() => {
		fetch(API_URL)
			.then((response) => {
				if (response.status === 200) {
					props.navigation.navigate("Login");
				} else {
					setError(true);
				}
			})
			.catch(() => {
				setError(true);
			});
	}, []);

	return (
		<View style={styles.content}>
			{error ? (
				<View>
					<Text style={styles.tittle}>Can't Connect 😦</Text>
					<Text style={styles.text}>
						Please verify you are connected to your home Wi-Fi to use the
						application. 🙂
					</Text>
				</View>
			) : (
				<View>
					<ActivityIndicator
						size="large"
						color="#26B7ED"
						style={styles.spinner}
					/>
					<Text style={styles.tittle}>Loading...</Text>
				</View>
			)}
		</View>
	);
}

const styles = StyleSheet.create({
	content: {
		flex: 1,
		justifyContent: "center",
		alignItems: "center",
		paddingHorizontal: 20,
		width: "100%",
		height: "100%",
	},
	spinner: {
		marginTop: 20,
		marginBottom: 40,
	},
	tittle: {
		textAlign: "center",
		fontWeight: "bold",
		fontSize: 18,
	},
	text: {
		textAlign: "center",
		fontSize: 18,
	},
});
