export class DoorActionType {
  static REQUEST = new DoorActionType("REQUEST");
  static FAILURE = new DoorActionType("FAILURE");

  constructor(name) {
    this.name = name;
  }
}
