param(
    [Parameter(Mandatory = $true)]
    [ValidateRange(1, 16)]
    [int]$Stage
)

$ErrorActionPreference = 'Stop'
$stageName = 'day{0:D2}' -f $Stage
$source = Join-Path $PSScriptRoot "stages\$stageName"
$destination = Join-Path $PSScriptRoot 'WpfTestApp'
$files = @(
    'WpfTestApp.csproj', 'App.xaml', 'App.xaml.cs',
    'MainWindow.xaml', 'MainWindow.xaml.cs', 'Post.cs', 'MainViewModel.cs'
)

if (-not (Test-Path -LiteralPath (Join-Path $source 'WpfTestApp.csproj'))) {
    throw "단계 파일을 찾지 못했습니다: $source"
}
if (-not (Test-Path -LiteralPath $destination -PathType Container)) {
    throw "예제 프로젝트 폴더를 찾지 못했습니다: $destination"
}

# 바꾸기 전의 교재 파일만 백업합니다. 사용자 추가 파일은 건드리지 않습니다.
$backupName = (Get-Date -Format 'yyyyMMdd-HHmmss') + '-' + [guid]::NewGuid().ToString('N')
$backup = Join-Path $PSScriptRoot ".stage-backups\$backupName"
New-Item -ItemType Directory -Path $backup -Force | Out-Null
foreach ($name in $files) {
    $current = Join-Path $destination $name
    if (Test-Path -LiteralPath $current) {
        Copy-Item -LiteralPath $current -Destination $backup
    }
}

foreach ($name in $files) {
    $incoming = Join-Path $source $name
    $current = Join-Path $destination $name
    if (Test-Path -LiteralPath $incoming) {
        Copy-Item -LiteralPath $incoming -Destination $current -Force
    }
    elseif (Test-Path -LiteralPath $current) {
        # 이전 단계에서만 사용하는 알려진 교재 파일을 정리합니다.
        Remove-Item -LiteralPath $current
    }
}

Write-Output "$stageName 완료본을 적용했습니다. Visual Studio에서 변경 파일을 다시 불러오세요."
Write-Output "이전 교재 파일 백업: $backup"
