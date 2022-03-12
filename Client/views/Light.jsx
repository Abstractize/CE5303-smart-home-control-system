import React, { useEffect } from "react";
import { connect } from "react-redux";
import { View, Text, Switch } from "react-native";
import { actionCreator as lightActionCreators } from "../store/action-creators/light-action-creators";

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
        <View style={{ flex: 1, alignItems: "center", justifyContent: "center" }}>
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
        </View>
    );
};

export default connect((state) => ({ ...state.light }), {
    ...lightActionCreators,
})(Light);
