import * as React from "react";
import { StyleSheet } from 'react-native';
import { NavigationContainer } from "@react-navigation/native";
import { createNativeStackNavigator } from "@react-navigation/native-stack";
import { Provider } from "react-redux";
import configureStore from './store';

import Login from './views/Login';
import Navigation from "./navigation/Navigation";

const Stack = createNativeStackNavigator();
const Store = configureStore();

export default function App() {
  return (
    <Provider store={Store}>
      <NavigationContainer>
        <Stack.Navigator>
          <Stack.Screen name="Main" component={Navigation} options={{ title: '', headerTransparent: true }} />
          <Stack.Screen name="Login" component={Login} options={{ title: '', headerTransparent: true }} />
        </Stack.Navigator>
      </NavigationContainer>
    </Provider>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: "#fff",
    alignItems: "center",
    justifyContent: "center",
  },
});
