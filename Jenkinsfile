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
				sh 'dotnet test TGS.Core.Infrastructures.Json.sln --logger \"trx;LogFileName=unit_tests.xml\" --no-build'

				step([$class: 'MSTestPublisher', testResultsFile:"**/*.trx", failOnError: true, keepLongStdio: true])
			}
		}
		
		stage('Push packages') {
			steps {
				sh 'dotnet pack -c $BuildConfiguration "./TGS.Core.Infrastructures.Json/TGS.Core.Infrastructures.Json.csproj" --no-build'
				sh 'dotnet nuget push "TGS.Core.Infrastructures.Json/bin/$BuildConfiguration/*.nupkg" --source "raypro" --skip-duplicate'
			}
		}
	}			
}