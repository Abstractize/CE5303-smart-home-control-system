import { View, Text, TouchableWithoutFeedback, StyleSheet, Image } from 'react-native'
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
            <Image style={styles.image} source={{uri: props.image.url}} />
            <View style={styles.textContainer}>
              <Text style={styles.text}>{props.image.name}</Text>
            </View>
          </View>
        </View>
      </View>
    </TouchableWithoutFeedback>
  )
}

const styles = StyleSheet.create({
  card: {
    flex: 1,
    height: 160,
    width: 160
  },
  spacing: {
    flex: 1,
    padding: 5,
  },
  bgStyles: {
    flex: 1,
    alignItems: 'center',
    justifyContent: 'center',
    borderRadius: 15,
    height: 160,
    width: 170
  }, 
  image: {
    width: '100%',
    height: '100%',
    borderRadius: 15
  },
  textContainer: {
    position: 'absolute',
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
    bottom: 10,
    padding: 6,
    width: '90%',
    backgroundColor: 'black',
    borderRadius: 15,
  },
  text: {
    lineHeight: 16,
    fontSize: 14,
    fontWeight: 'bold',
    color: 'white',
  }
})
