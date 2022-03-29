import { FlatList, StyleSheet, Platform, View } from "react-native";
import React from "react";

import ImageCard from "./ImageCard";

export default function PhotosList(props) {
	return (
		<View>
			<FlatList
				data={props.dataList}
				numColumns={2}
				showsVerticalScrollIndicator={false}
				keyExtractor={(data) => String(data.id)}
				renderItem={({ item }) => <ImageCard image={item} />}
				contentContainerStyle={styles.flatListContentContainer}
				onEndReachedThreshold={0.1}
			/>
		</View>
	);
}

const styles = StyleSheet.create({
	flatListContentContainer: {
		paddingTop: Platform.OS === "android" ? 30 : 0,
		paddingBottom: Platform.OS === "android" ? 5 : 0,
		paddingHorizontal: 5,
	},
});
