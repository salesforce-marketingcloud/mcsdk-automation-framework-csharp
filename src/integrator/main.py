from mcsdk.integration import runner
from bootstrap import *
from codebase.generator import CodeGenerator

# Vars for the integration run
repo_core_dir = cfg['repos']['core']['dir']
repo_sdk_dir = cfg['repos']['sdk']['dir']

# code generation components
generator = CodeGenerator(current_dir, cfg, config_dir, templates_dir, repo_sdk_dir)

# Run the integration
runner.run(config=cfg, code_generator=generator)
