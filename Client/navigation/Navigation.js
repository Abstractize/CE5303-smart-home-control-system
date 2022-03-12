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
    <Tap.Navigator initialRouteName='Home'>
      <Tap.Screen 
        name='Home' 
        component={Home} 
        options={{ headerShown: false, tabBarIcon: ({color, size}) => (
            <Icon name='home' color={color} size={size} />
          )
        }} 
      />
      <Tap.Screen 
        name='Light' 
        component={Light} 
        options={{
          tabBarLabel: 'Lights',
          headerShown: false,
          tabBarIcon: ({color, size}) => (
            <Icon name='lightbulb' color={color} size={size} />
          )
        }}
      />
      <Tap.Screen 
        name='Doors' 
        component={Door} 
        options={{ headerShown: false, tabBarIcon: ({ color, size }) => (
          <Icon name='door-closed' color={color} size={size} />
        )
      }}
      />
      <Tap.Screen 
        name='Photos' 
        component={Photo} 
        options={{ headerShown: false, tabBarIcon: ({ color, size }) => (
          <Icon name='images' color={color} size={size} />
        )
      }}
      />
    </Tap.Navigator>
  );
}