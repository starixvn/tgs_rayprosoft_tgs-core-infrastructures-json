pipeline {
    agent any
	
	environment {
		gitlab_user_pwd=credentials('gitlab-user-pwd')
        BuildConfiguration="Debug"
	}
	
    stages {
        stage('Clone') {
			steps {
				git branch: "develop", url: 'https://gitlab.com/rayprosoft/tgs-core-infrastructures-json.git' , credentialsId: 'gitlab-user-pwd'
			}
		}

        stage('Build') {
            steps {
                sh 'dotnet pack -c $BuildConfiguration "./TGS.Core.Infrastructures.Json/TGS.Core.Infrastructures.Json.csproj"'
            }
        }
		
		stage('Push packages') {
			steps {
				sh  'dotnet nuget push "TGS.Core.Infrastructures.Json/bin/$BuildConfiguration/*.nupkg" **/TGS*.nupkg --source "gitlab" --skip-duplicate'
			}
		}
	}			
}