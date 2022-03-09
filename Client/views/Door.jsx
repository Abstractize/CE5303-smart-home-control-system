import React from 'react';
import { connect } from 'react-redux';
import { View, Text } from 'react-native';
import { actionCreator as doorActionCreators } from '../store/action-creators/door-action-creators';

const Door = (props) => {
    props.start();
    props.get();

    console.log(props.data)

    return (
        <View style={{ flex: 1, alignItems: 'center', justifyContent: 'center' }}>
            <Text>Door Screen</Text>
        </View>
    )
}

export default connect(
    (state) => ({...state.door}), ({...doorActionCreators})
)(Door);