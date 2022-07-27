using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SIDE {RED,BLUE,GREEN,WHITE,YELLOW,PURPLE,UNDEF};
public enum ROT { N,E,S,W,CW,CCW};
public class sideDetector : MonoBehaviour
{

    [SerializeField] private topDetector tDet;
    [SerializeField] private fwdDetector fDet;
    [SerializeField] private playerControl pc;

    private SIDE ot = SIDE.UNDEF;
    private SIDE of = SIDE.UNDEF;

    private bool isSync = false;
    void Start(){
        StartCoroutine(WaitForCalibration());
    }

    IEnumerator WaitForCalibration(){
        yield return new WaitForSeconds(1);
        ot = tDet.getTop();
        of = fDet.getFront();
        isSync = true;
    }


    void Update()
    {
        if (!isSync) return;

        SIDE nt = tDet.getTop();
        SIDE nf = fDet.getFront();

        if (nf == SIDE.UNDEF) return;
        if (nt == SIDE.UNDEF) return;


        switch (ot){
            //+++++++++++++++++++++++++++++++++++++ TOP BLUE +++++++++++++++++++++++++++++++++++++++
            case SIDE.BLUE:
                if (of == SIDE.RED){

                    if (nf == SIDE.GREEN)   { Turn(ROT.CW);}else
                    if (nf == SIDE.YELLOW)  { Turn(ROT.CCW);}



                    if (nt == SIDE.RED)     { Turn(ROT.N);} else
                    if (nt == SIDE.YELLOW)  { Turn(ROT.E);} else
                    if (nt == SIDE.PURPLE)   { Turn(ROT.S);} else
                    if (nt == SIDE.GREEN)   { Turn(ROT.W);}
                    
                }
                else if(of == SIDE.YELLOW){

                    if (nf == SIDE.RED)     { Turn(ROT.CW);}else
                    if (nf == SIDE.PURPLE)   { Turn(ROT.CCW);}

                    if (nt == SIDE.YELLOW)  { Turn(ROT.N);} else
                    if (nt == SIDE.PURPLE)   { Turn(ROT.E);} else
                    if (nt == SIDE.GREEN)   { Turn(ROT.S);} else
                    if (nt == SIDE.RED)     { Turn(ROT.W);}
                }
                else if(of == SIDE.PURPLE){

                    if (nf == SIDE.YELLOW)  { Turn(ROT.CW);}else
                    if (nf == SIDE.GREEN)   { Turn(ROT.CCW);}

                    if (nt == SIDE.PURPLE)   { Turn(ROT.N);} else
                    if (nt == SIDE.GREEN)   { Turn(ROT.E);} else
                    if (nt == SIDE.RED)     { Turn(ROT.S);} else
                    if (nt == SIDE.YELLOW)  { Turn(ROT.W);}
}
                else if(of == SIDE.GREEN){

                    if (nf == SIDE.PURPLE)   { Turn(ROT.CW);}else
                    if (nf == SIDE.RED)     { Turn(ROT.CCW);}

                    if (nt == SIDE.GREEN)   { Turn(ROT.N);} else
                    if (nt == SIDE.RED)     { Turn(ROT.E);} else
                    if (nt == SIDE.YELLOW)  { Turn(ROT.S);} else
                    if (nt == SIDE.PURPLE)   { Turn(ROT.W);}
                }

                of = nf; ot = nt;

                break;

            //    //+++++++++++++++++++++++++++++++++++++ RED +++++++++++++++++++++++++++++++++++++++ 
            case SIDE.RED:

                 if (of == SIDE.WHITE){

                    if (nf == SIDE.GREEN)   { Turn(ROT.CW);}else
                    if (nf == SIDE.YELLOW)  { Turn(ROT.CCW);}

                    if (nt == SIDE.WHITE)   { Turn(ROT.N);} else
                    if (nt == SIDE.YELLOW)  { Turn(ROT.E);} else
                    if (nt == SIDE.BLUE)    { Turn(ROT.S);} else
                    if (nt == SIDE.GREEN)   { Turn(ROT.W);}
                    
                }
                else if(of == SIDE.YELLOW){

                    if (nf == SIDE.WHITE)  { Turn(ROT.CW);}else
                    if (nf == SIDE.BLUE)   { Turn(ROT.CCW);}

                    if (nt == SIDE.YELLOW) { Turn(ROT.N);} else
                    if (nt == SIDE.BLUE)   { Turn(ROT.E);} else
                    if (nt == SIDE.GREEN)  { Turn(ROT.S);} else
                    if (nt == SIDE.WHITE)  { Turn(ROT.W);}
                }
                else if(of == SIDE.BLUE){

                    if (nf == SIDE.YELLOW)  { Turn(ROT.CW);}else
                    if (nf == SIDE.GREEN)   { Turn(ROT.CCW);}

                    if (nt == SIDE.BLUE)    { Turn(ROT.N);} else
                    if (nt == SIDE.GREEN)   { Turn(ROT.E);} else
                    if (nt == SIDE.WHITE)   { Turn(ROT.S);} else
                    if (nt == SIDE.YELLOW)  { Turn(ROT.W);}
}
                else if(of == SIDE.GREEN){

                    if (nf == SIDE.BLUE)    { Turn(ROT.CW);}else
                    if (nf == SIDE.WHITE)   { Turn(ROT.CCW);}

                    if (nt == SIDE.GREEN)   { Turn(ROT.N);} else
                    if (nt == SIDE.WHITE)   { Turn(ROT.E);} else
                    if (nt == SIDE.YELLOW)  { Turn(ROT.S);} else
                    if (nt == SIDE.BLUE)    { Turn(ROT.W);}
                }

                of = nf; ot = nt;

                break;

            case SIDE.GREEN:
              
                 if (of == SIDE.WHITE){

                    if (nf == SIDE.PURPLE)   { Turn(ROT.CW);}else
                    if (nf == SIDE.RED)     { Turn(ROT.CCW);}

                    if (nt == SIDE.WHITE)   { Turn(ROT.N);} else
                    if (nt == SIDE.RED)     { Turn(ROT.E);} else
                    if (nt == SIDE.BLUE)    { Turn(ROT.S);} else
                    if (nt == SIDE.PURPLE)   { Turn(ROT.W);}
                    
                }
                else if(of == SIDE.RED){

                    if (nf == SIDE.WHITE)   { Turn(ROT.CW);}else
                    if (nf == SIDE.BLUE)    { Turn(ROT.CCW);}

                    if (nt == SIDE.RED)     { Turn(ROT.N);} else
                    if (nt == SIDE.BLUE)    { Turn(ROT.E);} else
                    if (nt == SIDE.PURPLE)   { Turn(ROT.S);} else
                    if (nt == SIDE.WHITE)   { Turn(ROT.W);}
                }
                else if(of == SIDE.BLUE){

                    if (nf == SIDE.RED)     { Turn(ROT.CW);}else
                    if (nf == SIDE.PURPLE)   { Turn(ROT.CCW);}

                    if (nt == SIDE.BLUE)    { Turn(ROT.N);} else
                    if (nt == SIDE.PURPLE)   { Turn(ROT.E);} else
                    if (nt == SIDE.WHITE)   { Turn(ROT.S);} else
                    if (nt == SIDE.RED)     { Turn(ROT.W);}
}
                else if(of == SIDE.PURPLE){

                    if (nf == SIDE.BLUE)    { Turn(ROT.CW);}else
                    if (nf == SIDE.WHITE)   { Turn(ROT.CCW);}

                    if (nt == SIDE.PURPLE)   { Turn(ROT.N);} else
                    if (nt == SIDE.WHITE)   { Turn(ROT.E);} else
                    if (nt == SIDE.RED)     { Turn(ROT.S);} else
                    if (nt == SIDE.BLUE)    { Turn(ROT.W);}
                }
                of = nf; ot = nt;

                break;
            case SIDE.YELLOW:

                 if (of == SIDE.WHITE){

                    if (nf == SIDE.RED)     { Turn(ROT.CW);}else
                    if (nf == SIDE.PURPLE)   { Turn(ROT.CCW);}

                    if (nt == SIDE.WHITE)   { Turn(ROT.N);} else
                    if (nt == SIDE.PURPLE)   { Turn(ROT.E);} else
                    if (nt == SIDE.BLUE)    { Turn(ROT.S);} else
                    if (nt == SIDE.RED)     { Turn(ROT.W);}
                    
                }
                else if(of == SIDE.RED){

                    if (nf == SIDE.BLUE)    { Turn(ROT.CW);}else
                    if (nf == SIDE.WHITE)   { Turn(ROT.CCW);}

                    if (nt == SIDE.RED)     { Turn(ROT.N);} else
                    if (nt == SIDE.WHITE)   { Turn(ROT.E);} else
                    if (nt == SIDE.PURPLE)   { Turn(ROT.S);} else
                    if (nt == SIDE.BLUE)    { Turn(ROT.W);}
                }
                else if(of == SIDE.BLUE){

                    if (nf == SIDE.PURPLE)   { Turn(ROT.CW);}else
                    if (nf == SIDE.RED)     { Turn(ROT.CCW);}

                    if (nt == SIDE.BLUE)    { Turn(ROT.N);} else
                    if (nt == SIDE.RED)     { Turn(ROT.E);} else
                    if (nt == SIDE.WHITE)   { Turn(ROT.S);} else
                    if (nt == SIDE.PURPLE)   { Turn(ROT.W);}
}
                else if(of == SIDE.PURPLE){

                    if (nf == SIDE.WHITE)   { Turn(ROT.CW);}else
                    if (nf == SIDE.BLUE)    { Turn(ROT.CCW);}

                    if (nt == SIDE.PURPLE)   { Turn(ROT.N);} else
                    if (nt == SIDE.BLUE)    { Turn(ROT.E);} else
                    if (nt == SIDE.RED)     { Turn(ROT.S);} else
                    if (nt == SIDE.WHITE)   { Turn(ROT.W);}
                }

                of = nf; ot = nt;


                break;
            case SIDE.WHITE:
                
                 if (of == SIDE.GREEN){

                    if (nf == SIDE.RED)     { Turn(ROT.CW);}else
                    if (nf == SIDE.PURPLE)   { Turn(ROT.CCW);}

                    if (nt == SIDE.GREEN)   { Turn(ROT.N);} else
                    if (nt == SIDE.PURPLE)   { Turn(ROT.E);} else
                    if (nt == SIDE.YELLOW)  { Turn(ROT.S);} else
                    if (nt == SIDE.RED)     { Turn(ROT.W);}
                    
                }
                else if(of == SIDE.RED){

                    if (nf == SIDE.YELLOW)  { Turn(ROT.CW);}else
                    if (nf == SIDE.GREEN)   { Turn(ROT.CCW);}

                    if (nt == SIDE.RED)     { Turn(ROT.N);} else
                    if (nt == SIDE.GREEN)   { Turn(ROT.E);} else
                    if (nt == SIDE.PURPLE)   { Turn(ROT.S);} else
                    if (nt == SIDE.YELLOW)  { Turn(ROT.W);}
                }
                else if(of == SIDE.YELLOW){

                    if (nf == SIDE.PURPLE)   { Turn(ROT.CW);}else
                    if (nf == SIDE.RED)     { Turn(ROT.CCW);}

                    if (nt == SIDE.YELLOW)  { Turn(ROT.N);} else
                    if (nt == SIDE.RED)     { Turn(ROT.E);} else
                    if (nt == SIDE.GREEN)   { Turn(ROT.S);} else
                    if (nt == SIDE.PURPLE)   { Turn(ROT.W);}
}
                else if(of == SIDE.PURPLE){

                    if (nf == SIDE.GREEN)   { Turn(ROT.CW);}else
                    if (nf == SIDE.YELLOW)  { Turn(ROT.CCW);}

                    if (nt == SIDE.PURPLE)   { Turn(ROT.N);} else
                    if (nt == SIDE.YELLOW)  { Turn(ROT.E);} else
                    if (nt == SIDE.RED)     { Turn(ROT.S);} else
                    if (nt == SIDE.GREEN)   { Turn(ROT.W);}
                }
                of = nf; ot = nt;
                break;

            case SIDE.PURPLE:

                 if (of == SIDE.WHITE){

                    if (nf == SIDE.YELLOW)  { Turn(ROT.CW);}else
                    if (nf == SIDE.GREEN)   { Turn(ROT.CCW);}

                    if (nt == SIDE.WHITE)   { Turn(ROT.N);} else
                    if (nt == SIDE.GREEN)   { Turn(ROT.E);} else
                    if (nt == SIDE.BLUE)    { Turn(ROT.S);} else
                    if (nt == SIDE.YELLOW)  { Turn(ROT.W);}
                    
                }
                else if(of == SIDE.YELLOW){

                    if (nf == SIDE.BLUE)    { Turn(ROT.CW);}else
                    if (nf == SIDE.WHITE)   { Turn(ROT.CCW);}

                    if (nt == SIDE.YELLOW)  { Turn(ROT.N);} else
                    if (nt == SIDE.WHITE)   { Turn(ROT.E);} else
                    if (nt == SIDE.GREEN)   { Turn(ROT.S);} else
                    if (nt == SIDE.BLUE)    { Turn(ROT.W);}
                }
                else if(of == SIDE.BLUE){

                    if (nf == SIDE.GREEN)   { Turn(ROT.CW);}else
                    if (nf == SIDE.YELLOW)  { Turn(ROT.CCW);}

                    if (nt == SIDE.BLUE)    { Turn(ROT.N);} else
                    if (nt == SIDE.YELLOW)  { Turn(ROT.E);} else
                    if (nt == SIDE.WHITE)   { Turn(ROT.S);} else
                    if (nt == SIDE.GREEN)   { Turn(ROT.W);}
}
                else if(of == SIDE.GREEN){

                    if (nf == SIDE.WHITE)   { Turn(ROT.CW);}else
                    if (nf == SIDE.BLUE)    { Turn(ROT.CCW);}

                    if (nt == SIDE.GREEN)   { Turn(ROT.N);} else
                    if (nt == SIDE.BLUE)    { Turn(ROT.E);} else
                    if (nt == SIDE.YELLOW)  { Turn(ROT.S);} else
                    if (nt == SIDE.WHITE)   { Turn(ROT.W);}
                }
                of = nf; ot = nt;
                break;

            default:
                break;
        }
    }

    //public SIDE getBottom()
    //{
    //    switch (ot)
    //    {
    //        case SIDE.RED:
    //            return SIDE.PURPLE;

    //        case SIDE.BLUE:
    //            return SIDE.WHITE;

    //        case SIDE.GREEN:
    //            return SIDE.YELLOW;

    //        case SIDE.YELLOW:
    //            return SIDE.GREEN;

    //        case SIDE.WHITE:
    //            return SIDE.BLUE;

    //        case SIDE.PURPLE:
    //            return SIDE.RED;

    //        default:
    //            return SIDE.UNDEF;

    //    }
    //}


    private void Turn(ROT dir){

        switch (dir){
            case ROT.N:
                pc.rollQueue.Enqueue(Vector3.forward);
                break;

            case ROT.E:
                pc.rollQueue.Enqueue(Vector3.right);
                break;

            case ROT.S:
                pc.rollQueue.Enqueue(Vector3.back);
                break;

            case ROT.W:
                pc.rollQueue.Enqueue(Vector3.left);
                break;

            case ROT.CW:
                pc.rollQueue.Enqueue(Vector3.up);
                break;

            case ROT.CCW:
                pc.rollQueue.Enqueue(Vector3.down);
                break;

            default:
                break;

        }
    }


}
