# SystemPrototype4915mProject

歡迎參與 這個項目 的開發！本文件提供基本指引，確保團隊協作順暢並保護 `master` 分支。請仔細閱讀以下步驟，特別是在克隆倉庫後如何創建自己的分支。

## 快速開始

### 1. 克隆倉庫
- **命令行（Git）**：
  ```bash
  git clone https://github.com/[你的用戶名]/[倉庫名稱].git
  cd [倉庫名稱]
  ```
- **GitHub Desktop**：
  1. 打開 GitHub Desktop。
  2. 點擊「File」 > 「Clone Repository」。
  3. 選擇本倉庫（[用戶名]/[倉庫名稱]），點擊「Clone」。
  4. 選擇本地保存路徑，完成克隆。

### 2. **重要：創建自己的分支**
- 請勿直接在 `master` 分支上編輯或提交代碼！`master` 分支受到保護，所有更改必須通過 Pull Request (PR) 合併。
- **為每個功能或修復創建新分支**：
  - **命名規範**：使用 `feature/你的名字-功能`（如 `feature/john-login-page`）或 `bugfix/問題描述`（如 `bugfix/fix-nav-bar`）。
  - **命令行（Git）**：
    ```bash
    # 確保在 master 分支並更新
    git checkout master
    git pull origin master

    # 創建並切換到新分支
    git checkout -b feature/你的名字-功能
    ```
  - **GitHub Desktop**：
    1. 確保當前分支是 `master`（在「Current Branch」下拉菜單確認）。
    2. 點擊「Branch」 > 「New Branch」。
    3. 輸入分支名稱（例如 `feature/你的名字-功能`），點擊「Create Branch」。
    4. 點擊「Publish Branch」將新分支推送到 GitHub。

### 3. 提交更改
- 在你的分支上編輯代碼並提交：
  - **命令行（Git）**：
    ```bash
    git add .
    git commit -m "描述你的更改，例如：添加登錄頁面"
    git push origin feature/你的名字-功能
    ```
  - **GitHub Desktop**：
    1. 在「Changes」標籤中查看你的更改。
    2. 輸入提交信息（例如「添加登錄頁面」）。
    3. 點擊「Commit to feature/你的名字-功能」。
    4. 點擊「Push origin」將更改推送到 GitHub。

### 4. 創建 Pull Request (PR)
- 完成工作後，提交 Pull Request 讓團隊審核：
  1. 訪問 GitHub 上的倉庫頁面。
  2. 點擊「Pull requests」標籤，然後點擊「New pull request」。
  3. 選擇你的分支（`feature/你的名字-功能`）作為「compare」，`master` 作為「base」。
  4. 填寫 PR 標題和描述（說明更改內容，關聯 Issue 可選）。
  5. 點擊「Create pull request」。
- 等待審核，根據反饋修改代碼（直接在你的分支提交新更改，PR 會自動更新）。

### 5. 注意事項
- **不要直接推送更改到 `master`**，否則會被拒絕（已設置分支保護）。
- 為每個獨立功能或修復創建新分支，避免在同一分支上堆積多個不相關更改。
- 提交 PR 時，清晰描述你的更改，方便審核。
- 如果使用 GitHub Desktop，定期點擊「Fetch origin」檢查遠端更新。

## 更多資源
- **[子系統控制器說明](aboutSubSystemController.md)**：請閱讀 `aboutSubSystemController.md` 文件，了解子系統控制器的詳細資訊。

## 問題與幫助
- 遇到 Git 或 GitHub Desktop 問題？請使用Discord聯繫 專案負責人 或在倉庫的 Issues 頁面提交問題。
- 推薦閱讀：[GitHub 官方 Pull Request 指南](https://docs.github.com/en/pull-requests/collaborating-with-pull-requests/proposing-changes-to-your-work-with-pull-requests/about-pull-requests)
