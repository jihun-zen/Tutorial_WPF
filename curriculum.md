# 4주 학습 커리큘럼

대상: C#과 MSSQL 기본 지식은 있지만 WPF, XAML, MVVM은 처음인 학습자.

목표: 화면 구성 → 이벤트 → 데이터 바인딩 → MVVM → 비동기 API 호출 순서로 이해하고, 하나의 작은 Windows 프로그램을 완성합니다.

각 주는 평일 30분씩 3회와 주말 120분 1회입니다. 표의 시간에는 개념 설명, 코드 확인, Visual Studio 실습, 핵심 요약을 모두 포함합니다. 설치 및 다운로드 대기 시간은 사전 준비 시간입니다.

## 1주차: WPF와 XAML 기초 — 210분

| 학습일 | 시간 | 학습 내용과 시간 배분 | 완료 시점 |
|---|---:|---|---|
| 평일 1일 | 30분 | 목표 2 + WPF·프로젝트 구조 8 + 코드 5 + 창 실행 12 + 요약 3 | 제목과 안내 문구가 있는 창 |
| 평일 2일 | 30분 | 목표 2 + XAML·Grid·StackPanel 7 + 코드 6 + 화면 배치 12 + 요약 3 | 입력창·버튼·결과 영역 배치 |
| 평일 3일 | 30분 | 목표 2 + 컨트롤·이벤트 6 + 코드 5 + 입력값 출력 14 + 요약 3 | 버튼을 누르면 입력값 표시 |
| 주말 1일 | 120분 | 목표 5 + 동작 흐름 15 + 코드 15 + 통합 실습 75 + 요약 10 | 빈 입력 안내를 포함한 텍스트 테스트 창 |

Grid는 행·열, Auto·별표 크기까지만 다룹니다. 이벤트 전달의 내부 구조나 화면 디자인은 생략합니다. DataGrid와 데이터 바인딩은 다음 주에 시작합니다.

교재: [1일차](lessons/week01/day01.md), [2일차](lessons/week01/day02.md), [3일차](lessons/week01/day03.md), [4일차](lessons/week01/day04.md).

## 2주차: 화면과 C# 데이터 연결 — 210분

교재: [1일차](lessons/week02/day01.md), [2일차](lessons/week02/day02.md), [3일차](lessons/week02/day03.md), [4일차](lessons/week02/day04.md).

| 학습일 | 시간 | 학습 내용과 시간 배분 | 기존 프로그램에 추가할 내용 |
|---|---:|---|---|
| 평일 1일 | 30분 | 목표 2 + DataGrid·목록 6 + 코드 5 + 실습 14 + 요약 3 | 게시글 클래스와 고정 데이터 2개, DataGrid.ItemsSource 지정 |
| 평일 2일 | 30분 | 목표 2 + Binding·DataContext·OneWay 7 + 코드 5 + 실습 13 + 요약 3 | 결과 문구를 public 속성에 바인딩하고 데이터의 기준 객체 확인 |
| 평일 3일 | 30분 | 목표 2 + TwoWay·변경 알림 7 + 코드 5 + 실습 13 + 요약 3 | 입력 속성에 TwoWay 연결, INotifyPropertyChanged로 상태 문구 갱신 |
| 주말 1일 | 120분 | 목표 5 + 컬렉션 알림 15 + 코드 15 + 통합 실습 75 + 요약 10 | ObservableCollection의 행 추가와 항목 속성 변경을 각각 확인 |

새 개념은 다음 연결에만 집중합니다.

- DataContext: 바인딩 경로를 찾기 시작하는 기준 객체. 2주차에는 학습 편의를 위해 창 자신을 사용합니다.
- OneWay: 데이터에서 화면으로 전달. TwoWay: 화면 편집값도 데이터에 전달. TwoWay가 입력 즉시 반영된다는 뜻은 아니므로 TextBox에 UpdateSourceTrigger=PropertyChanged를 명시합니다.
- INotifyPropertyChanged: 객체의 속성 변경 알림. 메서드 한 개로 반복 부분을 최소화합니다.
- ObservableCollection: 목록의 추가·삭제 알림. **항목 내부 속성 변경은 항목이 별도로 알려야 합니다.**

DataGrid는 읽기 전용이며 번호와 제목 두 열만 명시적으로 표시합니다. 정렬, 사용자 열 편집, 변환기, 유효성 검사 프레임워크는 제외합니다. 행 추가는 컬렉션 알림을 보는 학습 단계에서만 사용하며 최종 앱 기능으로 남기지 않습니다.

## 3주차: MVVM의 목적과 기본 구조 — 210분

교재: [1일차](lessons/week03/day01.md), [2일차](lessons/week03/day02.md), [3일차](lessons/week03/day03.md), [4일차](lessons/week03/day04.md).

| 학습일 | 시간 | 학습 내용과 시간 배분 | 기존 프로그램에서 바꿀 내용 |
|---|---:|---|---|
| 평일 1일 | 30분 | 목표 2 + 역할 분리·패턴 8 + 코드 4 + 파일 이동 실습 13 + 요약 3 | Post는 Model, XAML은 View, 상태·목록은 MainViewModel로 분리 |
| 평일 2일 | 30분 | 목표 2 + ViewModel·DataContext 6 + 코드 5 + 실습 14 + 요약 3 | 데이터 기준을 확인하고 실행 메서드도 ViewModel로 이동 |
| 평일 3일 | 30분 | 목표 2 + ICommand·Command 8 + 코드 5 + 실습 12 + 요약 3 | 실행과 실행 가능 여부의 역할 확인, Toolkit으로 버튼 연결 |
| 주말 1일 | 120분 | 목표 5 + Toolkit 개념 15 + 코드 15 + 리팩터링 실습 75 + 요약 10 | Code-behind의 데이터 처리 동작을 ViewModel의 Command로 이전 |

디자인 패턴은 “반복되는 구조 문제에 사용하는 역할 분담 방법”으로 설명합니다. 화면이 커질 때 한 파일에서 상태와 동작을 찾기 어려워지는 예를 통해 필요성을 연결합니다. 작은 프로그램에서 이벤트를 쓰는 것도 자연스러운 선택임을 함께 설명합니다.

CommunityToolkit.Mvvm의 ObservableObject, SetProperty, RelayCommand까지만 사용합니다. ICommand를 직접 길게 구현하거나 소스 생성기 문법까지 동시에 배우지 않습니다. Code-behind에는 InitializeComponent와 DataContext 설정을 남겨도 됩니다.

**실무·면접 기초:** Model은 데이터, View는 화면, ViewModel은 화면에 제공할 상태와 동작을 맡습니다. ViewModel은 TextBox나 DataGrid를 직접 찾아 수정하지 않습니다.

## 4주차: 비동기 REST GET 테스트 프로그램 — 210분

교재: [1일차](lessons/week04/day01.md), [2일차](lessons/week04/day02.md), [3일차](lessons/week04/day03.md), [4일차](lessons/week04/day04.md).

| 학습일 | 시간 | 학습 내용과 시간 배분 | 기존 프로그램에 추가할 내용 |
|---|---:|---|---|
| 평일 1일 | 30분 | 목표 2 + async/await·Task 7 + 코드 5 + 실습 13 + 요약 3 | Task.Delay로 대기 중 창이 반응하는지 확인, AsyncRelayCommand 도입 |
| 평일 2일 | 30분 | 목표 2 + HTTP GET·JSON 7 + 코드 5 + 실습 13 + 요약 3 | 재사용 HttpClient로 고정 URL GET, System.Net.Http.Json으로 Post 목록 변환 |
| 평일 3일 | 30분 | 목표 2 + URL 입력·오류 6 + 코드 5 + 실습 14 + 요약 3 | 입력 URL 사용, 기본 오류를 상태 문구로 표시 |
| 주말 1일 | 120분 | 목표 5 + 전체 연결 15 + 코드 15 + 통합 실습 75 + 요약 10 | GET 결과를 DataGrid에 표시하는 작은 프로그램 완성 |

마지막 주에 새로 만드는 화면은 없습니다. 기존 입력창을 URL 입력으로 바꾸고, 기존 목록을 API 결과로 채웁니다.

최종 요청은 [JSONPlaceholder 게시글 목록 API](https://jsonplaceholder.typicode.com/posts?userId=1)를 사용합니다. 2026-10-28에 공식 안내와 실제 응답의 userId·id·title·body 배열 구조를 확인했습니다. API는 외부 서비스이므로 호출 실습에는 인터넷 연결이 필요합니다.

처리 범위는 다음과 같이 고정합니다.

- 응답은 userId, id, title, body 속성이 있는 게시글 객체의 JSON 배열로 한정합니다. 화면에는 id와 title만 표시합니다. 다른 응답 구조에는 별도 클래스와 매핑이 필요하다고 설명합니다.
- URL의 http/https 형식 확인, HttpRequestException, JSON 변환 오류, 시간 초과 정도만 다룹니다. 마지막 날에는 양수 id와 비어 있지 않은 title을 확인합니다. 비어 있는 배열은 오류가 아니라 결과 0건으로 표시합니다. 첫 GET 단계부터 기본 catch를 제공하고 다음 날에 오류별 동작을 설명합니다.
- 호출 시작 시 이전 결과를 비우고 로딩 상태를 표시합니다. 호출 종료 시 성공 또는 오류 상태를 표시합니다.
- AsyncRelayCommand의 기본 중복 실행 방지를 활용합니다. 별도의 동시성 관리 기능은 만들지 않습니다.
- .Result와 .Wait() 대신 await를 사용합니다. await는 기다리는 동안 UI를 막지 않게 하는 방법이며, 새 스레드를 무조건 만드는 문법은 아닙니다.

DI, 서비스 계층, 취소 버튼, 재시도, 인증, SQL, 배포는 제외합니다. Task.Delay는 비동기를 관찰하기 위한 중간 단계이며 최종 요청 코드에서는 제거합니다.

## 진도를 줄일 때의 기준

시간이 부족하면 열 너비 조절과 부가 레이아웃 조정, 폴더 정리의 반복부터 줄입니다. Grid, 이벤트 연결, DataContext, 속성과 목록의 변경 알림 차이, Command, await를 통한 GET과 결과 표시를 우선합니다.

매주 새 기능을 더하기 전에 같은 프로젝트가 빌드되는 상태로 마칩니다. 별도 응용 과제나 문제 풀이 시간은 배정하지 않습니다.

전체는 210분 × 4주 = **840분(14시간)**입니다. 학습 속도에 따라 동일 실습을 천천히 진행해도 되며, 정해진 시간 안에 내용을 암기할 필요는 없습니다.
