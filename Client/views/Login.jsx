import React, { useState } from 'react'
import { connect } from 'react-redux';
import { View, Text, Button } from 'react-native';
import { Input } from '../components/Input';
import { actionCreator as authActionCreators } from '../store/action-creators/auth-action-creators';

const Login = (props) => {
   const [email, onChangeEmail] = React.useState();
   const [password, onChangePassword] = React.useState();
   return (
      <View style={{ flex: 1, alignItems: 'center', justifyContent: 'center' }}>
         <Text>Login Screen</Text>
         <Input placeholder="Email" onValueEntered={onChangeEmail}/>
         <Input placeholder="Password" onValueEntered={onChangePassword}/>
         {props.isLoading ? <Text>Loading...</Text>
         : <Button title='GO!' onPress={() => 
            props.login({email: email, password: password}, 
            props.navigation)} />}
      </View>
   )
}
export default connect(state => ({...state.auth}),
({...authActionCreators}))
(Login);