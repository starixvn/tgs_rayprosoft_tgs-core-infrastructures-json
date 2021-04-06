pipeline {
    agent any
	
	environment {
		gitlab_user_pwd=credentials('gitlab-user-pwd')
        BuildConfiguration="Debug"
	}

    stages {
        stage('Build') {
            steps {
                sh 'dotnet build -c $BuildConfiguration "./TGS.Core.Infrastructures.Json/TGS.Core.Infrastructures.Json.csproj"'
            }
        }

		stage('Test') {
			steps {
				sh 'dotnet test TGS.Core.Infrastructures.Json.sln -c $BuildConfiguration --logger trx --no-build'
			}
		}
		
		stage('Push packages') {
			steps {
				sh 'dotnet pack -c $BuildConfiguration "./TGS.Core.Infrastructures.Json/TGS.Core.Infrastructures.Json.csproj" --no-build'
				sh 'dotnet nuget push "TGS.Core.Infrastructures.Json/bin/$BuildConfiguration/*.nupkg" --source "raypro" --skip-duplicate'
			}
		}
	}
	post {
		always {
			step([$class: 'MSTestPublisher', testResultsFile:"**/*.trx", failOnError: false, keepLongStdio: true])
		}
	}
}