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
### 1. Sign-Up

- method : post
- url : "http://localhost:8080/user/sign-up"
- input format : {"name" : {string}, "password" : {string}}
- output format : <br> {"response" : true || false}


### 2. Sign-In

- method : post
- url : http://localhost:8080/user/sign-in
- input format : {"name" : {string}, "password" : {string}}
- output format : {"response" : true || false}

### 3. find All Users
- method : get
- url : http://localhost:8080/find-all
- input format : x
- output formate= : [ {"id" : {Long}, "name" : {string}, "password" : {string}} ... ]


## GameController 
### 1. player turn set
  - method : Post
  - url : http://localhost:8080/current/player-turn-set
  - input format : {"turn" {String}}
  - Note: The string that turn can have is "player1" or "player2"
  - output : {"valid" : true || false}


### 2. 순서 조회
  - getPlayerTurnInfo() : TurnForm
  - url : http://localhost:8080/current/player-turn-info
  - method : Get
  - input : x
  - output : TurnForm
  - 역할 : 플레이어 차례 조회

### 3. 플레이어 위치&블럭 설치 정보 업데이트
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
- 역할 : 플레이어의 좌표 업데이트 || 블럭 설치 정보 업데이트

### 4. 플레이어 정보 조회
- getPlayerInfo(int playerNum) : Player
- url : http://localhost:8080/fetch/info/player
- input : int playerNum
- output : Player
  - input : {
    "action" : {"moving" | "blocking"}  
    "row1" : {int}  
    "col1" : {int}  
    "row2" : {int}  
    "col2" : {int}  
  - }

### 장애물 유효성 검사
- IsValidInstall(Obstacle) : Validation
- method : post
- url : http://localhost:8080/install/block/valid
- input : {<br>
  "row1" : {int}
  "col1" : {int}
  "row2" : {int}
  "col2" : {int}
}
- output : Validation

### 장애물 설치
- IsValidInstall(Obstacle) : Validation
- method : post
- url : http://localhost:8080/install/block
- input : {<br>
  "row1" : {int}
  "col1" : {int}
  "row2" : {int}
  "col2" : {int}
}
- output : Validation

### 게임 끝 이후 결과 반영
- recordWinLose(WinLose) : Validation
- method : post
- url : http://localhost:8080/game/end
- input : {<br>
  "winner" : {int}  
  "loser" : {int}  
}
- output : Validation
## server-client 통신 api 호출 시나리오
--------------------------
### 플레이어1 차례로 가정
  1. 이동한 경우
      - step1 : updatePlayerInfo(PlayerForm) : Validation
      - step2 : setPlayerTurnInfo(TurnForm) : Validation   
      [플레이엉 좌표정보 업데이트 -> 차례 넘김]
      
  <br><br>
  1. 장애물을 설치하는 경우  
     - step1 : IsValidInstall(Obstacle) : Validation
     - step2 : updatePlayerInfo(PlayerForm) : Validation
     - step3 : - step2 : setPlayerTurnInfo(TurnForm) : Validation  
      [장애물 유효성 검사 -->장애물 설치 정보 반영 -> 차례넘김]
