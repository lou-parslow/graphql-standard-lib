NAME='{{cookiecutter.library_name}}'
VERSION='0.0.0'
require 'dev'

task :setup do
    Setup.setupStandardClassLib("#{NAME}",'C#') if(!Dir.exists?("#{NAME}"))
	Dir.chdir("#{NAME}.Test") do
		puts `dotnet add package coverlet.msbuild`
	end
	puts `nuget restore #{NAME}.sln`
end