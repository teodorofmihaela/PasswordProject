
import { Toolbar  } from '@mui/material';
import { Grid } from '@mui/material';
import { Typography } from '@mui/material';
import { Card } from '@mui/material';


import PasswordIcon from '@mui/icons-material/Password';

function Navbar(){
return(
    <Toolbar >
        <Grid container alignItems="center">
        <Card>
            <PasswordIcon/>
        </Card>
         <Typography>My website for generationg passwords</Typography>
        </Grid>
    </Toolbar >
);
}

export default Navbar;
