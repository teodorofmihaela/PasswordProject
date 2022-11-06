
import { Toolbar } from '@mui/material';
import { Grid } from '@mui/material';
import { Typography } from '@mui/material';
import { Paper } from '@mui/material';
import { Card } from '@mui/material';
import LockIcon from '@mui/icons-material/Lock';
import "./Navbar.css";


import PasswordIcon from '@mui/icons-material/Password';

function Navbar() {
    return (
        <Paper elevation={3} square className='paper'>
            <div className='wrapper'>
                <Grid container alignItems="center" className="container">
                    <Card className='card'>
                        <LockIcon className="icon" />
                    </Card>
                    <div className="pageTitle" style={{ "marginLeft": "20px" }} align="left">
                        <Typography variant="h6">Password Generator</Typography>
                        <div className="subtitle">
                            <Typography>My website for generationg passwords</Typography>
                        </div>
                    </div>
                </Grid>
            </div>
        </Paper>
    );
}

export default Navbar;
