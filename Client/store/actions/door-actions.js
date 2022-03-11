export class DoorActionType {
  static REQUEST = new DoorActionType("REQUEST");
  static FAILURE = new DoorActionType("FAILURE");
  static SUCCESS = new DoorActionType("SUCCESS");
  static CLOSE = new DoorActionType("CLOSE");

  constructor(name) {
    this.name = name;
  }
}
