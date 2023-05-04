## api 사용법
--------------------------
1. 회원가입       
  method : post
  data type : Json       
  url : "http://localhost:8080/sign-up"  
  input format : {"name" : {string}}  
  output format<br>
  회원가입 성공 -> {"response" : true}  
  회원가입 실패(중복 존재) -> {"response" false}  

1. 로그인  
   (해당 부분 작성 중)

## 계층 구조
---------------------------
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