import React, { useEffect } from 'react';
import { connect } from 'react-redux';
import { View, Text } from 'react-native';
import { actionCreator as doorActionCreators } from '../store/action-creators/door-action-creators';

const Door = (props) => {
    useEffect(() => {
        props.connect();

        return () => {
            props.disconnect();
        }
    }, []);

    useEffect(() => {
        props.getStream();
    }, [props.connection]);

    useEffect(() => {
        if(props.data)
            console.log(props.data);
    }, [props.data]);

    useEffect(() => {
        if(props.error)
            console.error(props.error);
    }, [props.error]);

    return (
        <View style={{ flex: 1, alignItems: 'center', justifyContent: 'center' }}>
            <Text>Door Screen</Text>
        </View>
    )
}

export default connect(
    (state) => ({ ...state.door }), ({ ...doorActionCreators })
)(Door);