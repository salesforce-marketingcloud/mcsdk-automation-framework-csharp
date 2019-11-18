from mcsdk.bootstrap import *

# directories
current_dir = os.path.join(TRAVIS_REPO_OWNER_DIR, cfg['repos']['current']['name'])

print('----- Bootstrap debug: -----')
print('Current directory: ' + current_dir + '\n')
