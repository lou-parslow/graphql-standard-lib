
task :test do
    FileUtils.rm_r('MyLib') if(Dir.exists?('MyLib'))
    FileUtils.mkdir('MyLib') if(!Dir.exists?('MyLib'))
    Dir.chdir('MyLib') do
        puts `cookiecutter #{File.dirname(__FILE__)} --no-input`
        Dir.chdir('GraphQLAPI.Library') do
            puts `rake`
        end
    end
    FileUtils.rm_r('MyLib')
end

task :default => [:test]