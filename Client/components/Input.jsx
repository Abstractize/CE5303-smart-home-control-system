import React from "react";
import { SafeAreaView, StyleSheet, TextInput } from "react-native";

export const Input = ({placeholder, onValueEntered}) => {
  const [text, onChangeText] = React.useState('');

  const handleChange = (text) =>{
    onChangeText(text);
    onValueEntered(text);
  }

  return (
    <SafeAreaView>
      <TextInput
        style={styles.input}
        onChangeText={handleChange}
        placeholder={placeholder}
        value={text}
      />
    </SafeAreaView>
  );
};

const styles = StyleSheet.create({
  input: {
    height: 40,
    margin: 12,
    borderWidth: 1,
    padding: 10,
  },
});