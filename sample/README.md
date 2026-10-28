# WPF 4주 예제 프로그램

[WpfTestApp.sln](WpfTestApp.sln)을 Visual Studio 2026으로 열고 F5로 실행합니다. Windows, .NET 10 SDK, .NET 데스크톱 개발 워크로드가 필요합니다.

현재 WpfTestApp 폴더는 **4주차 완료본(day16)**입니다. URL 입력 → Command → 비동기 GET → 게시글 JSON 배열 → DataGrid 표시가 구현되어 있습니다. 기본 주소는 https://jsonplaceholder.typicode.com/posts?userId=1 이며 인터넷 연결이 필요합니다.

예상 응답은 userId, id, title, body를 가진 게시글 배열입니다. 번호와 제목을 표에 표시하고, 최소한 id가 양수이고 title이 비어 있지 않은지 확인합니다. 이 데이터 계약과 다른 API를 사용하려면 Post 클래스와 매핑을 수정합니다.

## 날짜별 상태

| 단계 | 수업 | 완료 상태 |
|---|---|---|
| day01 | 1주차 1일 | 첫 창 |
| day02 | 1주차 2일 | 입력·버튼·결과 영역 배치 |
| day03 | 1주차 3일 | Click으로 입력값 표시 |
| day04 | 1주차 4일 | 빈 입력 안내 포함 텍스트 테스트 창 |
| day05 | 2주차 1일 | 고정 목록을 DataGrid에 표시 |
| day06 | 2주차 2일 | DataContext와 OneWay, 변경 알림 없는 상태 관찰 |
| day07 | 2주차 3일 | TwoWay와 INotifyPropertyChanged |
| day08 | 2주차 4일 | 행 추가와 기존 항목 변경 알림 |
| day09 | 3주차 1일 | 상태를 MainViewModel로 이동 |
| day10 | 3주차 2일 | 실행 동작도 ViewModel로 이동 |
| day11 | 3주차 3일 | Toolkit의 RelayCommand |
| day12 | 3주차 4일 | ObservableObject와 SetProperty |
| day13 | 4주차 1일 | 2초 비동기 대기, 중복 실행 방지 |
| day14 | 4주차 2일 | 코드에 고정한 URL GET, 기본 오류 처리 포함 |
| day15 | 4주차 3일 | 입력 URL 사용과 오류 처리 이해 |
| day16 | 4주차 4일 | 최소 응답 확인을 포함한 최종 API 테스트 창 |

stages는 같은 프로젝트의 완료 시점 보관본입니다. 각 폴더에 전체 소스와 csproj가 있으므로 중간 상태만 직접 빌드하는 것도 가능하지만, 수업에서는 WpfTestApp.sln 하나를 계속 사용합니다. stages 폴더를 WpfTestApp 안에 넣지 않습니다.

## 완료 시점 적용 — 권장

1. 실행 중인 앱을 닫습니다.
2. 저장소 루트에서 다음 명령을 실행합니다.
3. Visual Studio가 파일 변경을 물으면 다시 불러오고 솔루션을 빌드합니다.

```powershell
# 2주차를 시작하기 위한 1주차 완료 상태
powershell -ExecutionPolicy Bypass -File .\sample\Use-Stage.ps1 -Stage 4

# 3주차 시작 상태
powershell -ExecutionPolicy Bypass -File .\sample\Use-Stage.ps1 -Stage 8

# 4주차 시작 상태
powershell -ExecutionPolicy Bypass -File .\sample\Use-Stage.ps1 -Stage 12

# 최종 완료본
powershell -ExecutionPolicy Bypass -File .\sample\Use-Stage.ps1 -Stage 16
```

Stage에는 1~16의 정수를 지정합니다. 각 단계는 **그날의 완료본**이므로 2주차 1일차의 시작은 Stage 4, 완료는 Stage 5입니다.

Use-Stage.ps1은 WpfTestApp의 WpfTestApp.csproj, App.xaml, App.xaml.cs, MainWindow.xaml, MainWindow.xaml.cs, Post.cs, MainViewModel.cs만 대상으로 합니다. 단계에 없는 Post·ViewModel 파일은 정리합니다. 다른 사용자 파일이나 폴더를 삭제하지 않습니다. 기존 대상 파일은 매번 sample/.stage-backups의 새 폴더에 백업합니다. 복원이 필요하면 해당 백업의 교재 파일을 다시 복사하면 됩니다.

위 ExecutionPolicy 옵션은 이 스크립트를 실행하는 PowerShell 프로세스에만 적용하며 시스템의 영구 설정을 바꾸지 않습니다. 스크립트를 사용하지 않아도 아래 수동 적용으로 진행할 수 있습니다.

## 파일 탐색기로 수동 적용

1. 앱을 닫고 WpfTestApp의 교재 소스를 별도 폴더에 복사해 둡니다.
2. 원하는 stages/dayNN 폴더의 csproj, xaml, cs 파일을 WpfTestApp 폴더에 복사하여 교체합니다. bin·obj는 복사하지 않습니다.
3. 이전 단계로 돌아가는 경우 대상 단계에 Post.cs 또는 MainViewModel.cs가 없다면 WpfTestApp에 남아 있는 해당 파일을 제거합니다. 이 두 파일 외의 사용자 파일은 그대로 둡니다.
4. 솔루션을 다시 불러오고 빌드합니다.

같은 날짜의 파일을 함께 적용해야 XAML·C#·패키지 버전이 맞습니다. 1주차의 MainWindow 두 파일만 최종 프로젝트에 복사하면 이전 모델·ViewModel이 남으므로, 주차를 넘나들 때는 스크립트 또는 위 전체 파일 절차를 사용합니다.

## 패키지와 실행

day01~10에는 외부 NuGet 패키지가 없습니다. day11~16은 CommunityToolkit.Mvvm **8.4.2**를 사용합니다. csproj에 버전이 지정되어 있으며 첫 빌드 시 복원합니다. 다운로드 문제가 있으면 Visual Studio의 NuGet 원본 nuget.org와 인터넷 연결을 확인합니다.

API 사용은 day14부터입니다. day13은 인터넷 없이 Task.Delay로 비동기 대기를 관찰할 수 있습니다. System.Net.Http.Json은 .NET 10에 포함되어 별도 패키지를 추가하지 않습니다.

저장소 루트에서 실행합니다.

```powershell
dotnet build .\sample\WpfTestApp.sln
dotnet run --project .\sample\WpfTestApp\WpfTestApp.csproj

# 특정 완료 시점만 빌드
dotnet build .\sample\stages\day08\WpfTestApp.csproj
```

최종 프로그램은 URL 형식, HTTP 실패, JSON 형식과 최소 항목 조건, 시간 초과를 상태 문구로 안내합니다. 빈 배열은 결과 0건으로 표시합니다. 로그인, SQL, 파일 저장, 취소·재시도, 배포 기능은 없습니다.
