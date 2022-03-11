import { View, Text, TouchableWithoutFeedback, StyleSheet } from 'react-native'
import React from 'react'


export default function ImageCard(props) {

  const goToImage= () => {
    console.log('ID', props.image.id)
  }

  return (
    <TouchableWithoutFeedback onPress={goToImage}>
      <View style={styles.card}>
        <View style={styles.spacing}>
          <View style={styles.bgStyles}>
            <Text>{props.image.name}</Text>
            <Text>{props.image.id}</Text>
          </View>
        </View>
      </View>
    </TouchableWithoutFeedback>
  )
}

const styles = StyleSheet.create({
  card: {
    flex: 1,
    height: 130,
  },
  spacing: {
    flex: 1,
    padding: 5,
  },
  bgStyles: {
    flex: 1,
    borderRadius: 15,
    padding: 10,
    backgroundColor: '#45f',
  },  
})