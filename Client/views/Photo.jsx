import { Modal, View, Text, Pressable, StyleSheet } from 'react-native'
import React, { useEffect, useState } from 'react'
import Icon from 'react-native-vector-icons/FontAwesome';
import { actionCreator } from '../store/action-creators/photo-action-creators';
import { connect } from 'react-redux';
import { Video } from 'expo-av';

import PhotosList from '../components/photos/PhotosList';

function Photo(props) {
  const video = React.useRef(null);
  const [modalVisible, setModalVisible] = useState(false);
  const [url, setUrl] = useState('');

  useEffect(() => {
    //props.getPhotos();
  }, []);

  useEffect(() => {
    if(props.video !== null)
      setUrl(props.video.url);
    console.log(video);
  }, [props.video]);

  function onClick() {
    setModalVisible(true);
    props.getStreamUrl();
  }

  return (
    
  <Video
    ref={video}
    source={{
      uri: "http://qthttp.apple.com.edgesuite.net/1010qwoeiuryfg/sl.m3u8",
    }} 
    shouldPlay
    resizeMode="contain"
  />/*
    <View>
      <Modal
        animationType="slide"
        transparent={true}
        visible={!props.isVideoLoading && modalVisible}
        onRequestClose={() => {
          setModalVisible(false);
        }}
      >
        
        
      </Modal>
      <View style={styles.content}>
        <View style={styles.gallery_container}>
          <Text style={styles.gallery}>Gallery</Text>
          <PhotosList dataList={props.photo} />
        </View>
        <View style={styles.button_container}>
          <Pressable style={styles.button} onPress={onClick} >
            <Icon name="camera" color="#ffff" size={25} />
            <Text style={styles.text_button}>Take a Picture</Text>
          </Pressable>
        </View>
      </View>
    </View>
*/
  )
}

const styles = StyleSheet.create({
  content: {
    height: '100%',
    paddingVertical: '10%',
    marginTop: 50,
  },
  gallery_container: {
    height: '83%'
  },
  gallery: {
    textAlign: 'center',
    marginTop: 10,
    marginBottom: 30,
    fontSize: 28,
    fontWeight: 'bold',
  },
  button_container: {
    alignItems: 'center',
    height: 50,
    marginTop: 30,
    marginBottom: 30
  },
  button: {
    flex: 1,
    flexDirection: 'row',
    alignItems: 'center',
    justifyContent: 'space-around',
    width: '70%',
    paddingHorizontal: 20,
    borderRadius: 8,
    backgroundColor: '#35bbb4',
  },
  text_button: {
    textAlign: 'center',
    fontSize: 18,
    fontWeight: 'bold',
    letterSpacing: 0.55,
    color: 'white',
  },
});

export default connect(
  state => ({ ...state.photo }), ({ ...actionCreator })
)(Photo);