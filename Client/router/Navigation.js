import React from 'react';
import { createBottomTabNavigator } from "@react-navigation/bottom-tabs";

import Icon from 'react-native-vector-icons/FontAwesome5';

import Home from '../views/Home';
import Door from '../views/Door';
import Light from '../views/Light';
import Photo from '../views/Photo';

const Tap = createBottomTabNavigator();

export default function Navigation() {
  return (
    <Tap.Navigator initialRouteName='Light' screenOptions={({ route }) => ({
        headerShown: false,
        tabBarStyle: {
        height: 70,
        paddingHorizontal: 5,
        paddingTop: 0,
        backgroundColor: '#232e42',
        position: 'absolute',
        borderTopWidth: 0,
        },})
      }>
      <Tap.Screen 
        name='Home' 
        component={(props) => <Home {...props}/>} 
        options={{ tabBarLabel: '', headerShown: false, tabBarIcon: ({color}) => (
            <Icon name='home' color={color} size={30} />
          ),
          tabBarActiveTintColor: '#35bbb4',
          tabBarInactiveTintColor: 'white',
        }} 
      />
      <Tap.Screen 
        name='Light' 
        component={(props) => <Light {...props}/>} 
        options={{
          tabBarLabel: '',
          headerShown: false,
          tabBarIcon: ({color}) => (
            <Icon name='lightbulb' color={color} size={30} />
          ),
          tabBarActiveTintColor: '#35bbb4',
          tabBarInactiveTintColor: 'white',
        }}
      />
      <Tap.Screen 
        name='Doors' 
        component={(props) => <Door {...props} />} 
        options={{ tabBarLabel: '', headerShown: false, tabBarIcon: ({ color}) => (
          <Icon name='door-closed' color={color} size={30} />
        ),
        tabBarActiveTintColor: '#35bbb4',
        tabBarInactiveTintColor: 'white',
      }}
      />
      <Tap.Screen 
        name='Photos' 
        component={(props) => <Photo {...props}/>} 
        options={{ tabBarLabel: '', headerShown: false, tabBarIcon: ({ color}) => (
          <Icon name='images' color={color} size={30} />
        ),
        tabBarActiveTintColor: '#35bbb4',
        tabBarInactiveTintColor: 'white',
      }}
      />
    </Tap.Navigator>
  );
}