import { View, FlatList, StyleSheet, Platform } from "react-native";
import React from "react";

import LightCard from "./LightCard";

export default function LightsList(props) {
	return (
		<View>
			<FlatList
				data={props.dataList}
				numColumns={1}
				showsVerticalScrollIndicator={false}
				keyExtractor={(data) => String(data.id)}
				renderItem={({ item }) => (
					<LightCard light={item} changeSwitch={props.onChange} />
				)}
				contentContainerStyle={styles.flatListContentContainer}
				onEndReachedThreshold={0.1}
			/>
		</View>
	);
}

const styles = StyleSheet.create({
	flatListContentContainer: {
		marginTop: 20,
		paddingTop: Platform.OS === "android" ? 30 : 0,
		paddingBottom: Platform.OS === "android" ? 5 : 0,
		paddingHorizontal: 5,
	},
});
