pipeline {
    agent any
	
	environment {
		gitlab_user_pwd=credentials('gitlab-user-pwd')
        BuildConfiguration="Debug"
	}

    stages {
        stage('Build') {
            steps {
                sh 'dotnet pack -c $BuildConfiguration "./TGS.Core.Infrastructures.Json/TGS.Core.Infrastructures.Json.csproj"'
            }
        }

		stage('Test') {
			steps {
				sh 'dotnet test TGS.Core.Infrastructures.Json.sln --logger \"trx;LogFileName=unit_tests.xml\" --no-build'

				step([$class: 'MSTestPublisher', testResultsFile:"**/unit_tests.xml", failOnError: true, keepLongStdio: true])
			}
		}
		
		stage('Push packages') {
			steps {
				sh 'dotnet nuget push "TGS.Core.Infrastructures.Json/bin/$BuildConfiguration/*.nupkg" --source "raypro" --skip-duplicate'
			}
		}
	}			
}