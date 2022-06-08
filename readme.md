### 사운드오브좀비
![](https://velog.velcdn.com/images/yeah7598/post/646f7dc9-d763-4fb9-8363-e658d4de5d0b/image.png)
영상 url: https://drive.google.com/file/d/1uUk8_8IDOjjwsoqgcCVG69VpgsS1w9L_/view

알집 url: https://drive.google.com/file/d/18uf7c7O25iwtxDDu_EeidU1S8V-IPVf-/view?usp=sharing


### Intriduction

제한 시간 안에 좀비를 피해 음악상자를 찾는 코믹 좀비 게임

**게임 스토리** : 
음악을 좋아하는 사람이 모여 사는 나라에 좀비 바이러스가 퍼졌다.
사람들을 구하는 방법은 그들이 살아 생전에 즐겨 들었던 노래를 다시 들려주는 것뿐이다.

**게임 방법**:
1. 제한 시간 - 10분
2. 총 구해야하는 음악 상자 - 16개 (장르마다 4개)
3. 기본 목숨 - 3개

**게임 특징**
1. pop, 국악, 애니메이션, 클래식으로 총 4개의 구역이 존재하며,
구역마다 나오는 음악, 좀비가 다르다.
2. 사용자는 2개의 총을 가지며, 좀비에게 발사하여 좀비를 잠시 멈추거나 느리게 할 수 있다.
3. 좀비에게 물려 목숨을 모두 잃거나, 시간 안에 음악 상자를 구하지 못한다면 실패한다.
4. 좀비와 일정 거리 안으로 가까워 지면 좀비는 **사용자를 인식**하고 따라온다. (Unity NavMesh)
5. 음악 상자는 **3d 음향 효과**를 가지며, 위치에 따라 좌/우 소리가 다르게 들린다. 따라서 이를 통해 음악 상자의 위치를 파악할 수 있다.

### UI
![image](https://user-images.githubusercontent.com/29669560/172469656-10dc2213-d548-462e-853c-4a711ae56865.png)

![image](https://user-images.githubusercontent.com/29669560/172469315-258e7990-8643-42bf-b5cc-6cc4cf81c6b5.png)


### Tech Stack

<img src="https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white"/>
<img src="https://img.shields.io/badge/unity-%23000000.svg?style=for-the-badge&logo=unity&logoColor=white"/>
