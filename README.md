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

2. 모든 유저 조회  
  * method : get
  * url : http://localhost:8080/find-all
  * 주의점 : url은 로컬에서 실행하는 경우를 가정한 것
  * output 예시 : [ {"id" : 1, "name" : "성호"}, {"id" : 2, "name" : "팔달"},{"id" : 3, "name" : "율곡"} ]
  <br><br>

3. 플레이어 CRUD

플레이어 스탯 관리 API
---
**URL: `/stats/player`**

### POST `/create`
- 플레이어 스탯을 생성합니다.
- Request Body:
  - `Player`: 생성할 플레이어 스탯 정보를 담은 객체.
- Response:
  - `void`: 생성한 플레이어 스탯을 저장합니다.

### GET `/{id}`
- 해당 id를 가진 플레이어의 스탯을 가져옵니다.
- Path Variable:
  - `id`: 플레이어 고유 ID
- Response:
  - `Player`: 해당 id를 가진 플레이어의 스탯 정보를 담은 객체.

### PUT `/{id}`
- 해당 id를 가진 플레이어의 승패 정보를 업데이트합니다.
- Path Variable:
  - `id`: 플레이어 고유 ID
- Request Body:
  - `Map<String, Boolean>`: 업데이트할 승패 정보를 담은 맵. Key 값은 "wins"로 고정합니다.
- Response:
  - `void`: 업데이트한 승패 정보를 저장합니다.

### DELETE `/{id}`
- 해당 id를 가진 플레이어의 스탯을 삭제합니다.
- Path Variable:
  - `id`: 플레이어 고유 ID
- Response:
  - `void`: 삭제한 플레이어의 스탯을 저장합니다.

4. 플레이어 턴 전환

게임 턴 관리 API
---
**URL: `/turn/game`**

### GET `/currentPlayer`
- 현재 턴을 진행하는 플레이어 정보를 가져옵니다.
- Response:
  - `Player`: 현재 턴을 진행하는 플레이어 정보를 담은 객체.

### GET `/previousCoordinate`
- 직전에 놓인 돌의 좌표를 가져옵니다.
- Response:
  - `Coordinate`: 직전에 놓인 돌의 좌표 정보를 담은 객체.

### GET `/player/{playerId}`
- 해당 playerId를 가진 플레이어 정보를 가져옵니다.
- Path Variable:
  - `playerId`: 플레이어 고유 ID
- Response:
  - `Player`: 해당 playerId를 가진 플레이어 정보를 담은 객체.

### POST `/coordinate`
- 돌의 좌표를 서버에 전송합니다.
- Request Body:
  - `Coordinate`: 전송할 돌의 좌표 정보를 담은 객체.
- Response:
  - `void`: 서버에 돌의 좌표를 전송합니다.

### POST `/player/{playerId}/turnEnd`
- 해당 playerId를 가진 플레이어의 턴을 종료합니다.
- Path Variable:
  - `playerId`: 플레이어 고유 ID
- Response:
  - `void`: 서버에 해당 playerId를 가진 플레이어의 턴 종료 요청을 전송합니다.


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
