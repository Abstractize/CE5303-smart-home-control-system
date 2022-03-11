import * as React from "react";
import { StyleSheet } from 'react-native';
import { NavigationContainer } from "@react-navigation/native";
import { createNativeStackNavigator } from "@react-navigation/native-stack";
import { Provider } from "react-redux";
import Login from './views/Login';
import Home from './views/Home';
import Door from './views/Door'
import configureStore from './store'

const Stack = createNativeStackNavigator();
const Store = configureStore();

export default function App() {
  return (
    <Provider store={Store}>
      <NavigationContainer>
        <Stack.Navigator>
          <Stack.Screen name="Login" component={Login} options={{ title: '', headerTransparent: true }} />
          <Stack.Screen name="Door" component={Door} />
          <Stack.Screen name="Home" component={Home} />
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
