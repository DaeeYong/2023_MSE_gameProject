## Server Specification
  * project : gradle-Groovy
  * Language : java
  * Spring Boot Version : 2.7.11
  * Java Version : 11
  * 참고 홈페이지 : [https://start.spring.io/](https://start.spring.io/)

## api 사용법

1. 회원가입       
  * method : post
  * data type : Json       
  * url : "http://localhost:8080/sign-up"  
  * input format : {"name" : {string}}  
  * output format<br>
  * 회원가입 성공 -> {"response" : true}  
  * 회원가입 실패(중복 존재) -> {"response" false}  

2. 로그인
  * method : get
    * url : http://localhost:8080/sign-in
    * 주의점 : url은 로컬에서 실행하는 경우를 가정한 것
    * input : name
    * output : {"valid" : {Boolean} } //로그인에 성공한 경우 true, 실패한 경우 false
  
3. 모든 유저 조회  
  * method : get
  * url : http://localhost:8080/find-all
  * 주의점 : url은 로컬에서 실행하는 경우를 가정한 것
  * output 예시 : [ {"id" : 1, "name" : "성호"}, {"id" : 2, "name" : "팔달"},{"id" : 3, "name" : "율곡"} ]
  <br><br>

## 계층 구조
  ### DB 구조  
  DB를 바꿀 수 있도록, MemberRepository 라는 interface 사용  
  다른 DB를 이용하고자 한다면, 구현 class만 바꾸면 된다.  <br>

![DB 구조](/readmeImg/repository.png)


### 폴더 계층 구조
폴더의 형태는 아래 이미지와 같다.

![폴더 구조](/readmeImg/struct.png)

Controller : MVC에서 Controller를 의미한다.  
service : 핵심 로직들을 구현한 곳.  
repository : DB 접근을 위한 것들.  
domain : 서비스와 관련된 객체들이 들어있는 곳