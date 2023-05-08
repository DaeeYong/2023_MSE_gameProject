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

 3. 플레이어 턴 

이 API는 두 명의 플레이어가 차례대로 좌표를 놓아 장애물을 만들어 가며 진행되는 턴 게임입니다. 이 API를 사용하여 게임 플레이어를 조작할 수 있습니다.

베이스 URL: `localhost:8080/turn`

게임 현재 상태 조회
----
URL: `/game/currentPlayer`

Method: `GET`

Response Body Example:
```
{
    "id": "1",
    "name": "Player 1",
    "myTurn": true
}
```

- `id` (string): 플레이어 고유 식별자
- `name` (string): 플레이어 이름
- `myTurn` (boolean): 현재 해당 플레이어의 턴 여부

이 API는 현재 게임 상태에서 현재 차례인 플레이어를 조회할 수 있습니다.

이전 좌표 조회
----
URL: `/game/previousCoordinate`

Method: `GET`

Response Body Example:
```
{
    "x": 2,
    "y": 4
}
```

- `x` (integer): 이전에 놓았던 좌표의 x 값
- `y` (integer): 이전에 놓았던 좌표의 y 값

이 API는 현재 게임 상태에서 이전에 놓았던 좌표를 조회할 수 있습니다.

좌표 설정
----
URL: `/game/coordinate`

Method: `POST`

Request Body Example:
```
{
    "x": 2,
    "y": 5
}
```

- `x` (integer): 놓을 좌표의 x 값
- `y` (integer): 놓을 좌표의 y 값

Response Body: 없음

이 API는 현재 차례인 플레이어가 좌표를 놓을 때 호출합니다. 좌표가 유효한 경우 해당 좌표를 저장하고 다음 차례의 플레이어로 턴을 전환합니다. 유효하지 않은 경우 예외가 발생합니다.

플레이어 조회
----
URL: `/game/player/{playerId}`

Method: `GET`

Response Body Example:
```
{
    "id": "1",
    "name": "Player 1",
    "myTurn": true
}
```

- `id` (string): 플레이어 고유 식별자
- `name` (string): 플레이어 이름
- `myTurn` (boolean): 해당 플레이어의 턴 여부

- `{playerId}` (string): 조회할 플레이어의 고유 식별자

이 API는 플레이어의 고유 식별자를 입력받아 해당 플레이어 정보를 조회할 수 있습니다.

턴 종료

4. 플레이어 CRUD

PlayerDatabase API 문서

이 API는 게임 플레이어의 승률, 승, 패, 이름 등의 상태 정보를 관리합니다. 

# 엔드포인트

## GET /player/{id}

주어진 ID에 해당하는 플레이어의 상태 정보를 조회합니다.

### Request
- Path Parameter:
    - id: 조회하려는 플레이어의 ID (long)
    
### Response
- Status Code: 200
- Body:
    - id: 플레이어 ID (long)
    - name: 플레이어 이름 (string)
    - wins: 플레이어의 승리 수 (int)
    - losses: 플레이어의 패배 수 (int)
    - rates: 플레이어의 승률 (float)

### 예제

```
GET /player/1 HTTP/1.1
Host: example.com
```

```
HTTP/1.1 200 OK
Content-Type: application/json

{
    "id": 1,
    "name": "Player1",
    "wins": 3,
    "losses": 2,
    "rates": 0.6
}
```


## POST /player

새로운 플레이어의 상태 정보를 생성합니다.

### Request
- Body:
    - name: 플레이어 이름 (string)
    
### Response
- Status Code: 200
- Body:
    - id: 생성된 플레이어 ID (long)
    - name: 플레이어 이름 (string)
    - wins: 0 (int)
    - losses: 0 (int)
    - rates: 0.0 (float)

### 예제

```
POST /player HTTP/1.1
Host: example.com
Content-Type: application/json

{
    "name": "New Player"
}
```

```
HTTP/1.1 200 OK
Content-Type: application/json

{
    "id": 4,
    "name": "New Player",
    "wins": 0,
    "losses": 0,
    "rates": 0.0
}
```


## PUT /player/{id}

주어진 ID에 해당하는 플레이어의 상태 정보를 업데이트합니다.

### Request
- Path Parameter:
    - id: 업데이트하려는 플레이어의 ID (long)
- Body:
    - win: 승리 여부 (boolean)

### Response
- Status Code: 200

### 예제

```
PUT /player/1 HTTP/1.1
Host: example.com
Content-Type: application/json

{
    "win": true
}
```

```
HTTP/1.1 200 OK
```


## DELETE /player/{id}

주어진 ID에 해당하는 플레이어의 상태 정보를 삭제합니다.

### Request
- Path Parameter:
    - id: 삭제하려는 플레이어의 ID (long)

### Response
- Status Code: 200

### 예제

```
DELETE /player/1 HTTP/1.1
Host: example.com
```

```
HTTP/1.1 200 OK
```
----
URL: `/game/player/{playerId}/turnEnd
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
