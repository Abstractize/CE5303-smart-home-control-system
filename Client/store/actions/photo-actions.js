export class PhotoActionType {
  static REQUEST = new PhotoActionType("REQUEST");
  static REQUEST_PICTURE = new PhotoActionType("REQUEST_PICTURE");
  static REQUEST_VIDEO = new PhotoActionType("REQUEST_VIDEO");
  static SUCCESS = new PhotoActionType("SUCCESS");
  static FAILURE = new PhotoActionType("FAILURE");
  static SUCCESS_PICTURE = new PhotoActionType("SUCCESS_PICTURE");
  static SUCCESS_VIDEO = new PhotoActionType("SUCCESS_VIDEO");
  
  constructor(name) {
    this.name = name;
  }
}