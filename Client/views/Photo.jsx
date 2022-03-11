import { View, Text, SafeAreaView, Pressable, StyleSheet } from 'react-native'
import React from 'react'
import Icon from 'react-native-vector-icons/FontAwesome';

import PhotosList from '../components/photos/PhotosList';

export default function Photo() {
  return (
    <SafeAreaView>
      <View style={styles.button_content}>
        <Pressable style={styles.button} onPress={onClick}>
          <Icon name="camera" color="#ffff" size={20}/>
          <Text style={styles.text_button}>Take a Picture</Text>
        </Pressable>
      </View>
      <View>
      <Text>Gallery</Text>
        <PhotosList />
      </View>
    </SafeAreaView>
  )
}

const styles = StyleSheet.create({
  button_content: {
    flex: 1,
    alignItems: 'center',
    justifyContent: 'center',
    padding: 20,
    marginTop: 62,
  },
  button: {
    width: '60%',
    flex: 1,
    flexDirection: 'row',
    justifyContent: 'space-around',
    paddingHorizontal: 10,
    paddingVertical: 10,
    backgroundColor: '#35bbb4',
    borderRadius: 10,
  },
  text_button: {
    textAlign: 'center',
    paddingLeft: 20,
    fontSize: 16,
    lineHeight: 21,
    fontWeight: 'bold',
    letterSpacing: 0.55,
    color: 'white',
 },
});

function onClick () {
  console.log('Button Press');
}