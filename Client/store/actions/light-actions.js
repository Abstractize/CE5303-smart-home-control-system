export class LightActionType {
  static CONNECT = new LightActionType("CONNECT");
  static REQUEST = new LightActionType("REQUEST");
  static FAILURE = new LightActionType("FAILURE");
  static CLOSE = new LightActionType("CLOSE");

  constructor(name) {
    this.name = name;
  }
}
