export class PhotoActionType {
  static REQUEST = new PhotoActionType("REQUEST");
  static SUCCESS = new PhotoActionType("SUCCESS");
  static FAILURE = new PhotoActionType("FAILURE");

  constructor(name) {
    this.name = name;
  }
}