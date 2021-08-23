import React, { Component } from "react";
import XHR from "../logic/XHR.js";

export class Registration extends Component {
  constructor(props) {
    super(props);
    this.handleFormSubmitReg = this.handleFormSubmitReg.bind(this);
    this.handleFormSubmitLogin = this.handleFormSubmitLogin.bind(this);
    this.logout = this.logout.bind(this);
  }
  handleFormSubmitReg(e){
    e.preventDefault();
    let obj = {};
    new FormData(e.target).forEach((v,k)=>{obj[k]=v;});
    this.formSend('api/auth/register', obj, (resp)=>{
      alert(resp.message);
    }, (status, data)=>{
      if (!(data && status)) return false;
      //console.log(data);
      let resp = JSON.parse(data);
      if (!!resp.errors) {
        let errorsStr = '';
        for (let k in resp.errors) {
          errorsStr += k + '; ';
        }
        alert(`Ошибка: ${resp.message}\nПодробнее: ${errorsStr}`);
      } else {
        alert(resp.message);
      }
      return true;
    });
  }
  handleFormSubmitLogin(e){
    e.preventDefault();
    let obj = {};
    new FormData(e.target).forEach((v,k)=>{obj[k]=v;});
    this.formSend('api/auth/login', obj, (resp)=>{
      if (!!resp.token) {
        alert('Получен токен авторизации\nСообщение: '+resp.message);
      } else {
        alert(resp.Message);
      }
    });
  }
  logout(){
    XHR.sendXHRPostForm(XHR.backendURI+'api/auth/logout', {}, (data) => {
      let resp = JSON.parse(data);
      alert(resp.message);
    }, (status) => {
      if (!status) alert("Не удалось соединиться с сервером");
      else alert(`Не удалось произвести обмен данными с сервером (код статуса HTTP: ${status})`);
    });
  }

  formSend(route,obj,onSuccess,onFail){
    XHR.sendXHRPostJSON(XHR.backendURI+route, obj, (data) => {
      if (!!onSuccess) onSuccess(data);
    }, (status, data) => {
      if (!!onFail) {
        if (!!onFail(status,data))
          return;
      }
      if (!status) {
        alert("Не удалось соединиться с сервером");
        return;
      }
      alert(`Не удалось завершить операцию (код статуса HTTP: ${status})`);
    });
  }
  render() {
    return (
      <>
        <form onSubmit={this.handleFormSubmitReg}>
          {<>
            <input type="text" name="UserName" minLength={3} maxLength={20} required placeholder="Логин (3-20 символов)" /><br/>
            <input type="password" name="Password" required  placeholder="Пароль" /><br/>
            <input type="email" name="Email" required placeholder="Email" /><br/>
            <input type="submit" value="Регистрация" />
          </>}
        </form>
        <br />
      </>
    );
  }
}
