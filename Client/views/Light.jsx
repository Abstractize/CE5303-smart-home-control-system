import React, { useEffect } from "react";
import { connect } from "react-redux";
import { View, Text, StyleSheet } from "react-native";
import { actionCreator as lightActionCreators } from "../store/action-creators/light-action-creators";

import LightsList from "../components/lights/LightsList";

const Light = (props) => {
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
		if (props.error) console.error(props.error);
	}, [props.error]);

	return (
		/* <View style={{ flex: 1, alignItems: "center", justifyContent: "center" }}>
            <Text>Light Screen</Text>
            {props.data[0] ? (
                <View>
                    <Text>Light {props.data[0].roomName}</Text>
                    <Text>is {props.data[0].isOn ? "ON" : "OFF"}</Text>
                    <Switch
                        trackColor={{ false: "#767577", true: "#81b0ff" }}
                        thumbColor={props.data[0].isOn ? "#f5dd4b" : "#f4f3f4"}
                        ios_backgroundColor="#3e3e3e"
                        onValueChange={() =>
                            props.switchLight(props.data[0].id, {
                                ...props.data[0],
                                isOn: !props.data[0].isOn,
                            })
                        }
                        value={props.data[0].isOn}
                    />
                </View>
            ) : (
                <></>
            )}
        </View> */
		<View style={styles.content}>
			<View style={styles.light_container}>
				<Text style={styles.light}>Lights State</Text>
				<LightsList dataList={props.data} onChange={props.switchLight} />
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
	light_container: {
		height: "90%",
	},
	light: {
		textAlign: "center",
		marginTop: 10,
		marginBottom: 30,
		fontSize: 28,
		fontWeight: "bold",
	},
});

export default connect((state) => ({ ...state.light }), {
	...lightActionCreators,
})(Light);
