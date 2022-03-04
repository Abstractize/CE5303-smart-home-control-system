export class AuthActionType {
  static LOGIN = new AuthActionType("LOGIN");
  static LOGOUT = new AuthActionType("LOGOUT");
  static SUCCESS = new AuthActionType("SUCCESS");
  static FAILURE = new AuthActionType("FAILURE");

  constructor(name) {
    this.name = name;
  }
}
