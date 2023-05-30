## Server Specification

- project : gradle-Groovy
- Language : java
- Spring Boot Version : 2.7.11
- Java Version : 11
- 참고 홈페이지 : [https://start.spring.io/](https://start.spring.io/)

## 계층 구조

### DB 구조

DB를 바꿀 수 있도록, MemberRepository 라는 interface 사용  
 다른 DB를 이용하고자 한다면, 구현 class만 바꾸면 된다. <br>

![DB 구조](/readmeImg/repository.png)

### 폴더 계층 구조

폴더의 형태는 아래 이미지와 같다.

![폴더 구조](/readmeImg/struct.png)

Controller : MVC에서 Controller를 의미한다.  
service : 핵심 로직들을 구현한 곳.  
repository : DB 접근을 위한 것들.  
domain : 서비스와 관련된 객체들이 들어있는 곳

## UML

### Class Diagram

# server 회의 내용

![폴더 구조](/readmeImg/gameService.png)

## <이동관련한 내용만 포함됨>

## api 사용법

## UserController  
### 1. 회원가입

- method : post
- data type : Json
- url : "http://localhost:8080/user/sign-up"
- input format : {"name" : {string}, "password" : {string}}
- output format<br>
- 회원가입 성공 -> {"response" : true}
- 회원가입 실패(중복 존재) -> {"response" false}

### 2. 로그인

- method : post
- url : http://localhost:8080/user/sign-in
- 주의점 : url은 로컬에서 실행하는 경우를 가정한 것
- output format<br>
- 회원가입 성공 -> {"response" : true}
- 회원가입 실패(중복 존재) -> {"response" false}

### 3. 모든 유저 조회
- method : get
- url : http://localhost:8080/find-all
- 주의점 : url은 로컬에서 실행하는 경우를 가정한 것
- output 예시 : [ {"id" : 1, "name" : "성호"}, {"id" : 2, "name" : "팔달"},{"id" : 3, "name" : "율곡"} ]
  <br><br>


## GameController 
### 1. 순서 설정
  - setPlayerTurnInfo(TurnForm) : Validation 
  - url : http://localhost:8080/current/player-turn-set
  - method : Post
  - input : TurnForm --> {"turn" {String}}
  - 주의점 : turn이 가질 수 있는 문자열은 "player1" 또는 "player2"
  - output : Validation
  - 역할 : 플레이어 차례 set 

### 2. 순서 조회
  - getPlayerTurnInfo() : TurnForm
  - url : http://localhost:8080/current/player-turn-info
  - method : Get
  - input : x
  - output : TurnForm
  - 역할 : 플레이어 차례 조회

### 3. 플레이어 위치정보 업데이트
- updatePlayerInfo(PlayerForm) : Validation
- input : {<br>
    "playerNumber" :{int},<br>
    "action" : {String},<br>
    "x1" : {int},<br>
    "y1" : {int},<br>
    "x2" : {int/ default는 -1},<br>
    "y2" : {int/ default는 -1}<br>
}
- 주의점 : action이 가질 수 있는 상태는 "moving" 또는 "blocking"
- playerNumber는 1 또는 
- output : void
- 역할 : 플레이어의 초기 턴을 설정

### 4. 플레이어 이동 조회
- getPlayerInfo(int playerNum) : Player
- url : http://localhost:8080/move/info/player
- input : int playerNum
- output : Player
  - input : {
    "action" : {"moving" | "blocking"}
    "posX" : {int}
    "posY" : {int}
  - }

## server-client

p1이동 -> p1 위치 update -> p2모니터에 p1 그려줌 -> p2 차례


